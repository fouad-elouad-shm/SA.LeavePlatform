using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class LeaveTypeQueryRepository : ILeaveTypeQueryRepository
    {
        private SADbContext dbContext;
        public LeaveTypeQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddLeaveTypeAsync(LeaveType leaveType)
        {
            await dbContext.LeaveTypes.AddAsync(leaveType);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<LeaveType>> GetAllAsync()
        {
            return await dbContext.LeaveTypes.ToListAsync();
        }
        public async Task<LeaveType> GetByIdAsync(int id)
        {
            return await dbContext.LeaveTypes.FindAsync(id);
        }

        public async Task DeleteLeaveTypeAsync(int id)
        {
            var leaveType = await dbContext.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                dbContext.LeaveTypes.Remove(leaveType);
                await dbContext.SaveChangesAsync();
            }
        }

        public void AddLeaveType(LeaveType leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
