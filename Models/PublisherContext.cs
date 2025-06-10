using Microsoft.EntityFrameworkCore;

namespace publisher_app.Models
{
    public class PublisherContext:DbContext
    {
        public PublisherContext(DbContextOptions<PublisherContext> options):base(options) { }
        
        public DbSet<Publisher> Publishers { get; set; }=null!;

        public DbSet<Book> Books { get; set; } = null!;



    }
}
