using publisher_app.Models;

namespace publisher_app.Services
{
    public interface IDisciplineService
    {
        Task CreateDisciplineAsync(Publisher discipline);
        Task<IEnumerable<Publisher>> GetDisciplinesAsync();
        Task<Publisher> GetDisciplineAsync(long id);
        Task UpdateDisciplineAsync(Publisher discipline);
        Task DeleteDisciplineAsync(long id);
        Task<bool> DisciplineExistsAsync(long id);
    }
}
