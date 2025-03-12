using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface ILeaveDocQueryRepository
    {
        Task<IEnumerable<LeaveDoc>> GetAllAsync();
        void AddLeaveDoc(LeaveDoc leaveDoc);
        Task AddLeaveDocAsync(LeaveDoc leaveDoc);
        Task<LeaveDoc> GetByIdAsync(int id); // Add this method
        Task DeleteLeaveDocAsync(int id); // Add this method
    }
}
