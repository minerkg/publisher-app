namespace publisher_app.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public Publisher? Publisher { get; set; }
        public int? Year { get; set; }
        public double? Price { get; set; }
    }
}
