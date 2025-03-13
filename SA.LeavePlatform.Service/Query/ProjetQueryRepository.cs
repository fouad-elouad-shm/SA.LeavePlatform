using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class ProjetQueryRepository:IProjetQueryRepository
    {
        private SADbContext dbContext;
        public ProjetQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddProjetAsync(Projet projet)
        {
            await dbContext.Projets.AddAsync(projet);
            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Projet>> GetAllAsync()
        {
            return await dbContext.Projets.ToListAsync();
        }
        public async Task<Projet> GetByIdAsync(int id)
        {
            return await dbContext.Projets.FindAsync(id) ?? throw new KeyNotFoundException("Projet not found");
        }

        public async Task DeleteProjetAsync(int id)
        {
            var projet = await dbContext.Projets.FindAsync(id);
            if (projet != null)
            {
                dbContext.Projets.Remove(projet);
                await dbContext.SaveChangesAsync();
            }
        }

        public void AddProjet(Projet projet)
        {
            throw new NotImplementedException();
        }
    }
}
