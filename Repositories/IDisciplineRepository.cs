using catalog_disciplines.Models;

namespace catalog_disciplines.Repositories
{
    public interface IDisciplineRepository
    {
        Task CreateDisciplineAsync(Discipline discipline);
        Task<IEnumerable<Discipline>> GetDisciplinesAsync();
        Task<Discipline> GetDisciplineAsync(long id);
        Task UpdateDisciplineAsync(Discipline discipline);
        Task DeleteDisciplineAsync(long id);
        Task<bool> DisciplineExistsAsync(long id);
    }
}
