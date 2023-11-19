namespace Fluent_Api.Infrastructure.Dtos
{
    public class BookDto
    {
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
    }
}
