using catalog_disciplines.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog_disciplines.Repositories
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly DisciplineContext _disciplineContext;

        public DisciplineRepository(DisciplineContext disciplineContext)
        {
            _disciplineContext = disciplineContext;
        }

        public async Task CreateDisciplineAsync(Discipline discipline)
        {
            _disciplineContext.Disciplines.Add(discipline);
            await _disciplineContext.SaveChangesAsync();

        }

        public async Task DeleteDisciplineAsync(long id)
        {
            var discipline = _disciplineContext.Disciplines.FirstOrDefault(discipline => discipline.Id == id) 
                ?? throw new ArgumentException("id not found");
            _disciplineContext.Disciplines.Remove(discipline);
            await _disciplineContext.SaveChangesAsync();
        }

        public async Task<bool> DisciplineExistsAsync(long id)
        {
            return await _disciplineContext.Disciplines.AnyAsync(d => d.Id==id);
        }

        public async Task<Discipline> GetDisciplineAsync(long id)
        {
            return await _disciplineContext.Disciplines.FirstOrDefaultAsync(discipline => discipline.Id == id);
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesAsync()
        {
            return await _disciplineContext.Disciplines.ToListAsync();
        }

        public async Task UpdateDisciplineAsync(Discipline discipline)
        {
            _disciplineContext.Entry(discipline).State = EntityState.Modified;
            await _disciplineContext.SaveChangesAsync();
        }
    }
}
