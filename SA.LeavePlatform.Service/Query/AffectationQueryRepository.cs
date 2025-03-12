using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

namespace SA.LeavePlatform.Service.Query
{
    public class AffectationQueryRepository :IAffectationQueryRepository
    {
        private SADbContext dbContext;
        public AffectationQueryRepository(SADbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAffectationAsync(Affectation affectation)
        {
            await dbContext.Affectations.AddAsync(affectation);
            
            dbContext.Entry(affectation).Reference(e => e.Projet).IsModified = false;  // Ignore Projet
            dbContext.Entry(affectation).Reference(e => e.Employee).IsModified = false;  // Ignore employee

            await dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Affectation>> GetAllAsync()
        {
            return await dbContext.Affectations.ToListAsync();
        }
        public async Task<Affectation> GetByIdAsync(int id)
        {
            return await dbContext.Affectations.FindAsync(id);
        }

        public async Task DeleteAffectationsAsync(int id)
        {
            var affectation = await dbContext.Affectations.FindAsync(id);
            if (affectation != null)
            {
                dbContext.Affectations.Remove(affectation);
                await dbContext.SaveChangesAsync();
            }
        }

        public void AddAffectation(Affectation affectation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAffectationAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
