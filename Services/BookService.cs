using publisher_app.Models;
using publisher_app.Repositories;
using System.Diagnostics;

namespace publisher_app.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public BookService(IBookRepository bookRepository, RabbitMQPublisher rabbitMQPublisher)
        {
            _bookRepository = bookRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task<bool> BookExistsAsync(long id)
        {
            return await _bookRepository.BookExistsAsync(id);
        }

        public async Task CreateBookAsync(Book book)
        {
            Debug.WriteLine("creating new book");
            await _bookRepository.CreateBookAsync(book);
            _rabbitMQPublisher.PublishMessage($"New book added: {book.Title}, {book.Author}, {book.Year}, {book.Price}, {book.Publisher}");
        }

        public async Task DeleteBookAsync(long id)
        {
           await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<Book> GetBookAsync(long id)
        {
            return await _bookRepository.GetBookAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetBooksAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateBookAsync(book);
        }
    }
}
