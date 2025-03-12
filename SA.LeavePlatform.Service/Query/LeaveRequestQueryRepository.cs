using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class LeaveRequestQueryRepository : ILeaveRequestQueryRepository
    {
        private SADbContext dbContext;
        public LeaveRequestQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            await dbContext.LeaveRequests.AddAsync(leaveRequest);

            dbContext.Entry(leaveRequest).Reference(e => e.Status).IsModified = false;  // Ignore Status
            dbContext.Entry(leaveRequest).Reference(e => e.LeaveType).IsModified = false;  // Ignore Leave Type
            dbContext.Entry(leaveRequest).Reference(e => e.Employee).IsModified = false;  // Ignore employee
         


            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await dbContext.LeaveRequests.ToListAsync();
        }
        public async Task<LeaveRequest> GetByIdAsync(int id)
        {
            return await dbContext.LeaveRequests.FindAsync(id) ?? throw new KeyNotFoundException("Leave Request not found");
        }

        public async Task DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await dbContext.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                dbContext.LeaveRequests.Remove(leaveRequest);
                await dbContext.SaveChangesAsync();
            }
        }

        public void AddLeaveRequest(LeaveRequest leaveRequest)
        {
            throw new NotImplementedException();
        }
    }
}
