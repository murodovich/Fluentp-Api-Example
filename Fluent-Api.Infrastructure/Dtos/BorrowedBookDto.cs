namespace Fluent_Api.Infrastructure.Dtos
{
    public class BorrowedBookDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
