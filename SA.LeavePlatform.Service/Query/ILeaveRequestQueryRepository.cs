using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface ILeaveRequestQueryRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
        void AddLeaveRequest(LeaveRequest leaveRequest);
        Task AddLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest> GetByIdAsync(int id); // Add this method
        Task DeleteLeaveRequestAsync(int id); // Add this method
    }
}
