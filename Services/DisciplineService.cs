using publisher_app.Models;
using publisher_app.Repositories;
using System.Diagnostics;

namespace publisher_app.Services
{
    public class DisciplineService : IDisciplineService
    {

        private readonly IPublisherRepository _disciplineRepository;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public DisciplineService(IPublisherRepository disciplineRepository, RabbitMQPublisher rabbitMQPublisher)
        {
            _disciplineRepository = disciplineRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task CreateDisciplineAsync(Publisher discipline)
        {
            Debug.WriteLine("creating new discipline");
            await _disciplineRepository.CreatePublisherAsync(discipline);
            _rabbitMQPublisher.PublishMessage($"New discipline added: {discipline.Title}");
        }

        public async Task DeleteDisciplineAsync(long id)
        {
            await _disciplineRepository.DeletePublisherAsync(id);
        }

        public async Task<bool> DisciplineExistsAsync(long id)
        {
            return await _disciplineRepository.PublisherExistsAsync(id);
        }

        public async Task<Publisher> GetDisciplineAsync(long id)
        {
            return await _disciplineRepository.GetPublisherAsync(id);
        }

        public async Task<IEnumerable<Publisher>> GetDisciplinesAsync()
        {
            return await _disciplineRepository.GetPublishersAsync();
        }

        public async Task UpdateDisciplineAsync(Publisher discipline)
        {
            await _disciplineRepository.UpdatePublisherAsync(discipline);
        }
    }
}
