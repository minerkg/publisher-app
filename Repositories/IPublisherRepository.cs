using publisher_app.Models;

namespace publisher_app.Repositories
{
    public interface IPublisherRepository
    {
        Task CreatePublisherAsync(Publisher publisher);
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherAsync(long id);
        Task UpdatePublisherAsync(Publisher publisher);
        Task DeletePublisherAsync(long id);
        Task<bool> PublisherExistsAsync(long id);
    }
}
