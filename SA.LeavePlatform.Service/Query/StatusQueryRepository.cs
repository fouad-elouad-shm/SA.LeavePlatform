using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class StatusQueryRepository : IStatusQueryRepository
    {
        private SADbContext dbContext;
        public StatusQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddStatusAsync(Status status)
        {
            await dbContext.Statuses.AddAsync(status);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await dbContext.Statuses.ToListAsync();
        }

        public void AddStatus(Status status)
        {
            throw new NotImplementedException();
        }
        public async Task<Status> GetByIdAsync(int id)
        {
            return await dbContext.Statuses.FindAsync(id) ?? throw new KeyNotFoundException("Status not found");
        }

        public async Task DeleteStatusAsync(int id)
        {
            var status = await dbContext.Statuses.FindAsync(id);
            if (status != null)
            {
                dbContext.Statuses.Remove(status);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
