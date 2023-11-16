using System.ComponentModel.DataAnnotations;

namespace Fluent_Api.Domaiin.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
