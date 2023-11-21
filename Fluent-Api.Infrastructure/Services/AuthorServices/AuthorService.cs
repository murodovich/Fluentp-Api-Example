using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDBContext _dbContext;

        public AuthorService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<int> CreateAsync(AuthorDto model)
        {
            Author author = new Author();
            author.AuthorName = model.AuthorName;
            author.Country = model.Country;
            author.DateOfBirth = model.DateOfBirth.Date;

            await _dbContext.Authors.AddAsync(author);
            var result = await _dbContext.SaveChangesAsync();
            return result;
                       
        }

        public async ValueTask<int> DeleteAsync(int Id)
        {
            var result = await _dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId == Id);
             _dbContext.Authors.Remove(result);
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }

        public async ValueTask<List<Author>> GetAllAsync()
        {
            var result = await _dbContext.Authors.ToListAsync();
            return result;
        }

        public async ValueTask<Author> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId==Id);
            return result;
        }

        public async ValueTask<int> UpdateAsync(int Id, AuthorDto model)
        {
            var result = await _dbContext.Authors.FirstOrDefaultAsync(x => x.AuthorId == Id);
            result.DateOfBirth = model.DateOfBirth.Date;
            result.AuthorName = model.AuthorName;
            result.Country = model.Country;

            _dbContext.Authors.Update(result);
            var res = await _dbContext.SaveChangesAsync();
            return res;
            
        }
    }
}
