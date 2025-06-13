using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using publisher_app.Models;
using publisher_app.Services;


namespace publisher_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;
        public BookController(IBookService bookSevice)
        {
            _bookService = bookSevice;
        }

        // Get : api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        // Get : api/Books/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
            var book = await _bookService.GetBookAsync(id);
            return Ok(book);
        }

        // Post : api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDto book)
        {
            Console.WriteLine(book.PublisherId);
            Console.WriteLine(book.Title);
            await _bookService.CreateBookAsync(book);
            return Ok(book);
        }

        // Put : api/Books/2
        [HttpPut]
        public async Task<ActionResult<Book>> PutBook(long id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            if (!await _bookService.BookExistsAsync(id))
            {
                return NotFound();
            }
            await _bookService.UpdateBookAsync(book);
            return NoContent();
        }



        // Delete : api/Books/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
            }
            catch (ArgumentException) { return NotFound(); }
            return NoContent();

        }
    }
}
