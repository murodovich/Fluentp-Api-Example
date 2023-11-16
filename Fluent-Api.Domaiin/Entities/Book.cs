using System.ComponentModel.DataAnnotations;

namespace Fluent_Api.Domaiin.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }



        public Author Author { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set;}

    }
}
