using publisher_app.Models;
using publisher_app.Repositories;
using System.Diagnostics;

namespace publisher_app.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(IBookRepository bookRepository, RabbitMQPublisher rabbitMQPublisher, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
            _publisherRepository = publisherRepository;
        }

        public async Task<bool> BookExistsAsync(long id)
        {
            return await _bookRepository.BookExistsAsync(id);
        }

        public async Task CreateBookAsync(BookDto bookDto)
        {
            Debug.WriteLine("creating new book");
            var newBook = new Book();
            var publisher = await _publisherRepository.GetPublisherAsync(bookDto.PublisherId);
            if (publisher == null)
            {
                throw new Exception("Publisher not found");
            }
            newBook.Publisher = publisher;
            newBook.Title = bookDto.Title;
            newBook.Author = bookDto.Author;
            newBook.Year = bookDto.Year;
            newBook.Price = bookDto.Price;
            
            await _bookRepository.CreateBookAsync(newBook);
            _rabbitMQPublisher.PublishMessage($"New book added: {newBook.Title}, {newBook.Author}, {newBook.Year}, {newBook.Price}, {newBook.Publisher}");
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
