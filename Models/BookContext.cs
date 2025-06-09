using Microsoft.EntityFrameworkCore;

namespace publisher_app.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<PublisherContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;



    }
}