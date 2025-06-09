using catalog_disciplines.Models;

namespace catalog_disciplines.Services
{
    public interface IDisciplineService
    {
        Task CreateDisciplineAsync(Discipline discipline);
        Task<IEnumerable<Discipline>> GetDisciplinesAsync();
        Task<Discipline> GetDisciplineAsync(long id);
        Task UpdateDisciplineAsync(Discipline discipline);
        Task DeleteDisciplineAsync(long id);
        Task<bool> DisciplineExistsAsync(long id);
    }
}
