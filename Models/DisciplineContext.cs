using Microsoft.EntityFrameworkCore;

namespace catalog_disciplines.Models
{
    public class DisciplineContext:DbContext
    {
        public DisciplineContext(DbContextOptions<DisciplineContext> options):base(options) { }
        
        public DbSet<Discipline> Disciplines { get; set; }=null!;
        


    }
}
