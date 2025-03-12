using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface ILeaveTypeQueryRepository
    {
        Task<IEnumerable<LeaveType>> GetAllAsync();
        void AddLeaveType(LeaveType leaveType);
        Task AddLeaveTypeAsync(LeaveType leaveType);
        Task<LeaveType> GetByIdAsync(int id); // Add this method
        Task DeleteLeaveTypeAsync(int id); // Add this method
    }
}
