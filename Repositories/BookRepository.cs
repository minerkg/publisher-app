using publisher_app.Models;
using Microsoft.EntityFrameworkCore;

namespace publisher_app.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly PublisherContext _publisherContext;

        public BookRepository(PublisherContext bookContext)
        {
            _publisherContext = bookContext;
        }

        public async Task CreateBookAsync(Book book)
        {
            _publisherContext.Books.Add(book);
            await _publisherContext.SaveChangesAsync();

        }

        public async Task DeleteBookAsync(long id)
        {
            var book = _publisherContext.Books.FirstOrDefault(book => book.Id == id)
                ?? throw new ArgumentException("id not found");
            _publisherContext.Books.Remove(book);
            await _publisherContext.SaveChangesAsync();
        }

        public async Task<bool> BookExistsAsync(long id)
        {
            return await _publisherContext.Books.AnyAsync(book => book.Id == id);
        }

        public async Task<Book> GetBookAsync(long id)
        {
            return await _publisherContext.Books
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _publisherContext.Books
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _publisherContext.Entry(book).State = EntityState.Modified;
            await _publisherContext.SaveChangesAsync();
        }
    }
}

