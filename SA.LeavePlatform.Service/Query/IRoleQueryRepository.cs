using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface IRoleQueryRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        void AddRole(Role role);
        Task AddRoleAsync(Role role);
        Task<Role> GetByIdAsync(int id); // Add this method
        Task DeleteRoleAsync(int id); // Add this method
        Task UpdateRoleAsync(Role role);
    }
}
