using System.ComponentModel.DataAnnotations;

namespace Fluent_Api.Domaiin.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
