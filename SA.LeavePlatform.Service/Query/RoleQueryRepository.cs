using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class RoleQueryRepository:IRoleQueryRepository
    {
        private SADbContext dbContext;
        public RoleQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddRoleAsync(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }
        public async Task<Role> GetByIdAsync(int id)
        {
            return await dbContext.Roles.FindAsync(id);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await dbContext.Roles.FindAsync(id);
            if (role != null)
            {
                dbContext.Roles.Remove(role);
                await dbContext.SaveChangesAsync();
            }
        }


        public void AddRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
