using System.ComponentModel.DataAnnotations;

namespace Fluent_Api.Domaiin.Entities
{
    public class BorrowedBook
    {
        [Key]
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }


        public Book Book { get; set; }
        public User User { get; set; }
    }
}
