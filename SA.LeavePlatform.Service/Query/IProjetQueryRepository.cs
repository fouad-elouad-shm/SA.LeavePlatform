using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.Query
{
    public interface IProjetQueryRepository
    {
        Task<IEnumerable<Projet>> GetAllAsync();
        void AddProjet(Projet projet);
        Task AddProjetAsync(Projet projet);
        Task<Projet> GetByIdAsync(int id); // Add this method
        Task DeleteProjetAsync(int id); // Add this method
    }
}
