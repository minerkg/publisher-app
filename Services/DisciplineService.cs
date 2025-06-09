using publisher_app.Models;
using publisher_app.Repositories;
using System.Diagnostics;

namespace publisher_app.Services
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

        public async Task CreateDisciplineAsync(Publisher discipline)
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

        public async Task<Publisher> GetDisciplineAsync(long id)
        {
            return await _disciplineRepository.GetDisciplineAsync(id);
        }

        public async Task<IEnumerable<Publisher>> GetDisciplinesAsync()
        {
            return await _disciplineRepository.GetDisciplinesAsync();
        }

        public async Task UpdateDisciplineAsync(Publisher discipline)
        {
            await _disciplineRepository.UpdateDisciplineAsync(discipline);
        }
    }
}
