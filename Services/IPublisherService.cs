using publisher_app.Models;

namespace publisher_app.Services
{
    public interface IPublisherService
    {
        Task CreatePublisherAsync(Publisher publisher);
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherAsync(long id);
        Task UpdatePublisherAsync(Publisher publisher);
        Task DeletePublisherAsync(long id);
        Task<bool> PublisherExistsAsync(long id);
    }
}
