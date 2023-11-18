using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.CategpryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _dbContext;

        public CategoryService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<int> CreateAsync(CategoryDto model)
        {
            Category category = new Category();
            category.CategoryName = model.CategoryName;

            await _dbContext.Categories.AddAsync(category);
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }

        public async ValueTask<int> DeleteAsync(int Id)
        {
            var result = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == Id);
            _dbContext.Categories.Remove(result);
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }

        public async ValueTask<IList<Category>> GetAllAsync()
        {
            var result = await _dbContext.Categories.ToListAsync();
            return result;
        }

        public async ValueTask<Category> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == Id);
            return result;
        }

        public async ValueTask<int> UpdateAsync(int Id, CategoryDto model)
        {
            var result = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == Id);
            result.CategoryName = model.CategoryName;

            _dbContext.Categories.Update(result);
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }
    }
}
