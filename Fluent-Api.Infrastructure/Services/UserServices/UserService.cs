using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.UserServices
{
    public class UserService : IUserService
    {
        
        private readonly AppDBContext _dbcontext;

        public UserService(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
           
        }

        public async ValueTask<int> CreateAsync(UserDto model)
        {
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            user.UserName = model.UserName;
            user.Phone = model.Phone;
            _dbcontext.Users.Add(user);
            int result = await _dbcontext.SaveChangesAsync();
            return result;

            
        }

        public  ValueTask<int> DeleteAsync(int Id)
        {
            throw new NotImplementedException();

        }

        public async ValueTask<IList<User>> GetAllAsync()
        {
            var user = await _dbcontext.Users.ToListAsync();
            return user;
        }

        public async ValueTask<User> GetByIdAsync(int Id)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.UserId == Id);
            return user;
        }

        public async ValueTask<int> UpdateAsync(int Id, UserDto model)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.UserId == Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            user.UserName = model.UserName;
            user.Phone = model.Phone;
            _dbcontext.Users.Update(user);
            var result = await _dbcontext.SaveChangesAsync();
            return result;

        }
    }
}
