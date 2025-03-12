using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class LeaveDocQueryRepository:ILeaveDocQueryRepository
    {
        private SADbContext dbContext;
        public LeaveDocQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddLeaveDocAsync(LeaveDoc leaveDoc)
        {
            await dbContext.LeaveDocs.AddAsync(leaveDoc);
            dbContext.Entry(leaveDoc).Reference(e => e.LeaveRequest).IsModified = false;  // Ignore Role
            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<LeaveDoc>> GetAllAsync()
        {
            return await dbContext.LeaveDocs.ToListAsync();
        }
        public async Task<LeaveDoc> GetByIdAsync(int id)
        {
            return await dbContext.LeaveDocs.FindAsync(id);
        }

        public async Task DeleteLeaveDocAsync(int id)
        {
            var leaveDoc = await dbContext.LeaveDocs.FindAsync(id);
            if (leaveDoc != null)
            {
                dbContext.LeaveDocs.Remove(leaveDoc);
                await dbContext.SaveChangesAsync();
            }
        }

        public void AddLeaveDoc(LeaveDoc leaveDoc)
        {
            throw new NotImplementedException();
        }
    }
}
