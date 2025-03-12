using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface IAffectationQueryRepository
    {
        Task<IEnumerable<Affectation>> GetAllAsync();
        void AddAffectation(Affectation affectation);
        Task AddAffectationAsync(Affectation affectation);
        Task<Affectation> GetByIdAsync(int id); // Add this method
        Task DeleteAffectationAsync(int id); // Add this method
    }
}
