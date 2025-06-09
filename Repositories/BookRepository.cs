using publisher_app.Models;
using Microsoft.EntityFrameworkCore;

namespace publisher_app.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;

        public BookRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task CreateBookAsync(Book book)
        {
            _bookContext.Books.Add(book);
            await _bookContext.SaveChangesAsync();

        }

        public async Task DeleteBookAsync(long id)
        {
            var book = _bookContext.Books.FirstOrDefault(book => book.Id == id)
                ?? throw new ArgumentException("id not found");
            _bookContext.Books.Remove(book);
            await _bookContext.SaveChangesAsync();
        }

        public async Task<bool> BookExistsAsync(long id)
        {
            return await _bookContext.Books.AnyAsync(book => book.Id == id);
        }

        public async Task<Book> GetBookAsync(long id)
        {
            return await _bookContext.Books.FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _bookContext.Books.ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _bookContext.Entry(book).State = EntityState.Modified;
            await _bookContext.SaveChangesAsync();
        }
    }
}

