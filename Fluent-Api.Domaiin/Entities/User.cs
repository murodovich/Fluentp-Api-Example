using System.ComponentModel.DataAnnotations;

namespace Fluent_Api.Domaiin.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public ICollection<BorrowedBook> BorrowedBooks { get; set; }


    }
}
