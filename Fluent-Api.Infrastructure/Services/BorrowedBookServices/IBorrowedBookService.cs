using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;

namespace Fluent_Api.Infrastructure.Services.BorrowedBookServices
{
    public interface IBorrowedBookService : IBaseService<BorrowedBook,BorrowedBookDto>
    {
    }
}
