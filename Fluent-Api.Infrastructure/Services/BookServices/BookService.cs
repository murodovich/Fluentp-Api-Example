using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly AppDBContext _dbContext;
        public async ValueTask<int> CreateAsync(BookDto model)
        {
            Book book = new Book();
            book.BookName = model.BookName;
            book.AuthorId = model.AuthorId;
            book.ISBN = model.ISBN;
            book.PublicationYear = model.PublicationYear;
            book.Publisher = model.Publisher;

            await _dbContext.Books.AddAsync(book);
            var result = await _dbContext.SaveChangesAsync();
            return result;

        }

        public async ValueTask<int> DeleteAsync(int Id)
        {
            var result = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            _dbContext.Books.Remove(result);
            var res = await _dbContext.SaveChangesAsync(); 
            return res;
        }

        public async ValueTask<List<Book>> GetAllAsync()
        {
            var result = await _dbContext.Books.ToListAsync();
            return result;
        }

        public async ValueTask<Book> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            return result;
        }

        public async ValueTask<int> UpdateAsync(int Id, BookDto model)
        {
            var result = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == Id);

            result.BookName = model.BookName;
            result.AuthorId = model.AuthorId;
            result.ISBN = model.ISBN;
            result.PublicationYear = model.PublicationYear;
            result.Publisher = model.Publisher;

            _dbContext.Books.Update(result);
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }
    }
}
