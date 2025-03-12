using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;


namespace SA.LeavePlatform.Service.Query
{
    public class EmployeeQueryRepository : IEmployeeQueryRepository
    {
        private SADbContext dbContext;
        public EmployeeQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            dbContext.Entry(employee).Reference(e => e.Role).IsModified = false;  // Ignore Role
            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await dbContext.Employees.FindAsync(id);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }



        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
