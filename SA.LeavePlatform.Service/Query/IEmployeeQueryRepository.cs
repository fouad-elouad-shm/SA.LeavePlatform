using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface IEmployeeQueryRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        void AddEmployee(Employee employee);
        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetByIdAsync(int id); // Add this method
        Task DeleteEmployeeAsync(int id); // Add this method
        Task UpdateAsync(Employee employee);
    }
}
