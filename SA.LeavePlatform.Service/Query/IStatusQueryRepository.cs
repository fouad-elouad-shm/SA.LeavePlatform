using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface IStatusQueryRepository
    {
        Task<IEnumerable<Status>> GetAllAsync();
        void AddStatus(Status status);
        Task AddStatusAsync(Status status);
        Task<Status> GetByIdAsync(int id); // Add this method
        Task DeleteStatusAsync(int id); // Add this method

    }
}
