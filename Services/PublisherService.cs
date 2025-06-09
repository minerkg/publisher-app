using publisher_app.Models;
using publisher_app.Repositories;
using System.Diagnostics;

namespace publisher_app.Services
{
    public class PublisherService : IPublisherService
    {

        private readonly IPublisherRepository _publisherRepository;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public PublisherService(IPublisherRepository publisherRepository, RabbitMQPublisher rabbitMQPublisher)
        {
            _publisherRepository = publisherRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task CreatePublisherAsync(Publisher publisher)
        {
            Debug.WriteLine("creating new publisher");
            await _publisherRepository.CreatePublisherAsync(publisher);
            _rabbitMQPublisher.PublishMessage($"New publisher added: {publisher.Name}");
        }

        public async Task DeletePublisherAsync(long id)
        {
            await _publisherRepository.DeletePublisherAsync(id);
        }

        public async Task<bool> PublisherExistsAsync(long id)
        {
            return await _publisherRepository.PublisherExistsAsync(id);
        }

        public async Task<Publisher> GetPublisherAsync(long id)
        {
            return await _publisherRepository.GetPublisherAsync(id);
        }

        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            return await _publisherRepository.GetPublishersAsync();
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            await _publisherRepository.UpdatePublisherAsync(publisher);
        }
    }
}
