namespace publisher_app.Models
{
    public class BookDto
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public long PublisherId { get; set; }
        public int? Year { get; set; }
        public double? Price { get; set; }
    }
}
