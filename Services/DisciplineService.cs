using catalog_disciplines.Models;
using catalog_disciplines.Repositories;
using System.Diagnostics;

namespace catalog_disciplines.Services
{
    public class DisciplineService : IDisciplineService
    {

        private readonly IDisciplineRepository _disciplineRepository;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public DisciplineService(IDisciplineRepository disciplineRepository, RabbitMQPublisher rabbitMQPublisher)
        {
            _disciplineRepository = disciplineRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task CreateDisciplineAsync(Discipline discipline)
        {
            Debug.WriteLine("creating new discipline");
            await _disciplineRepository.CreateDisciplineAsync(discipline);
            _rabbitMQPublisher.PublishMessage($"New discipline added: {discipline.Title}");
        }

        public async Task DeleteDisciplineAsync(long id)
        {
            await _disciplineRepository.DeleteDisciplineAsync(id);
        }

        public async Task<bool> DisciplineExistsAsync(long id)
        {
            return await _disciplineRepository.DisciplineExistsAsync(id);
        }

        public async Task<Discipline> GetDisciplineAsync(long id)
        {
            return await _disciplineRepository.GetDisciplineAsync(id);
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesAsync()
        {
            return await _disciplineRepository.GetDisciplinesAsync();
        }

        public async Task UpdateDisciplineAsync(Discipline discipline)
        {
            await _disciplineRepository.UpdateDisciplineAsync(discipline);
        }
    }
}
