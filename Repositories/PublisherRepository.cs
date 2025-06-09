using publisher_app.Models;
using Microsoft.EntityFrameworkCore;

namespace publisher_app.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly PublisherContext _publisherContext;

        public PublisherRepository(PublisherContext publisherContext)
        {
            _publisherContext = publisherContext;
        }

        public async Task CreatePublisherAsync(Publisher publisher)
        {
            _publisherContext.Publishers.Add(publisher);
            await _publisherContext.SaveChangesAsync();

        }

        public async Task DeletePublisherAsync(long id)
        {
            var publisher = _publisherContext.Publishers.FirstOrDefault(publisher => publisher.Id == id) 
                ?? throw new ArgumentException("id not found");
            _publisherContext.Publishers.Remove(publisher);
            await _publisherContext.SaveChangesAsync();
        }

        public async Task<bool> PublisherExistsAsync(long id)
        {
            return await _publisherContext.Publishers.AnyAsync(publisher => publisher.Id==id);
        }

        public async Task<Publisher> GetPublisherAsync(long id)
        {
            return await _publisherContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == id);
        }

        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            return await _publisherContext.Publishers.ToListAsync();
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            _publisherContext.Entry(publisher).State = EntityState.Modified;
            await _publisherContext.SaveChangesAsync();
        }
    }
}
