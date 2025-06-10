using publisher_app.Models;

namespace publisher_app.Services
{
    public interface IBookService
    {
        Task CreateBookAsync(Book book);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(long id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(long id);
        Task<bool> BookExistsAsync(long id);
    }
}
