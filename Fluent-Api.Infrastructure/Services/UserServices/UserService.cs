using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        private readonly AppDBContext _dbcontext;

        public UserService(AppDBContext dbcontext,IUserService userService)
        {
            _dbcontext = dbcontext;
            _userService = userService;
        }

        public ValueTask<int> CreateAsync(UserDto model)
        {
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            user.UserName = model.UserName;
            user.Phone = model.Phone;
            _dbcontext.Users.Add(user);
            int result = _dbcontext.SaveChanges();
            if(result == 0)
            {
                return new ValueTask<int>(0);
            }
            return new ValueTask<int>(result);

            
        }

        public ValueTask<int> DeleteAsync(int Id)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.UserId == Id);
            if (user != null)
            {
                _dbcontext.Users.Remove(user);
                
            }
            return new ValueTask<int>(0);
            
        }

        public async ValueTask<IList<User>> GetAllAsync()
        {
            var user = await _dbcontext.Users.ToListAsync();
            return user;
        }

        public ValueTask<User> GetByIdAsync(int Id)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.UserId == Id);
            return new ValueTask<User>(user);            
        }

        public ValueTask<int> UpdateAsync(int Id, UserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
