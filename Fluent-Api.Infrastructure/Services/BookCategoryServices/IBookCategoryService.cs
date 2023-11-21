using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;

namespace Fluent_Api.Infrastructure.Services.BookCategoryServices
{
    public interface IBookCategoryService : IBaseService<BookCategory, BookCategoryDto>
    {
    }
}
