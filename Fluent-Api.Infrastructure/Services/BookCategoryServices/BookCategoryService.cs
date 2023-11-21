using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.BookCategoryServices
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly AppDBContext _dbcontext;

        public BookCategoryService(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async ValueTask<int> CreateAsync(BookCategoryDto model)
        {
            BookCategory bookCategory = new BookCategory();
            bookCategory.BookId = model.BookId;
            bookCategory.CategoryId = model.CategoryId;

            await _dbcontext.BookCategories.AddAsync(bookCategory);
            var result = await _dbcontext.SaveChangesAsync();
            return result;
        }

        public async ValueTask<int> DeleteAsync(int Id)
        {
            var result = await _dbcontext.BookCategories.FirstOrDefaultAsync(x => x.BookCategoryId == Id);
             _dbcontext.BookCategories.Remove(result);
            var res = await _dbcontext.SaveChangesAsync();
            return res;

        }

        public async ValueTask<List<BookCategory>> GetAllAsync()
        {
            var result = await _dbcontext.BookCategories.ToListAsync();
            return result;
        }

        public async ValueTask<BookCategory> GetByIdAsync(int Id)
        {
            var result = await _dbcontext.BookCategories.FirstOrDefaultAsync(x => x.BookCategoryId == Id);
            return result;
    
        }

        public async ValueTask<int> UpdateAsync(int Id, BookCategoryDto model)
        {
            var result = await _dbcontext.BookCategories.FirstOrDefaultAsync(x => x.BookCategoryId == Id);

            BookCategory bookCategory = new BookCategory();
            bookCategory.BookId = model.BookId;
            bookCategory.CategoryId = model.CategoryId;

            _dbcontext.BookCategories.Update(bookCategory);
            var res = await _dbcontext.SaveChangesAsync();
            return res;
        }
    }
}
