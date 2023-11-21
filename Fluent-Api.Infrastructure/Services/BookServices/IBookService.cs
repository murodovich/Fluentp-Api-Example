using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;

namespace Fluent_Api.Infrastructure.Services.BookServices
{
    public interface IBookService : IBaseService<Book,BookDto>
    {

    }
}
