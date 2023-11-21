using Faluent_Api.Application;
using Fluent_Api.Domaiin.Entities;
using Fluent_Api.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Infrastructure.Services.BorrowedBookServices
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly AppDBContext _dbContext;

        public BorrowedBookService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<int> CreateAsync(BorrowedBookDto model)
        {
            BorrowedBook borrowedBook = new BorrowedBook();
            borrowedBook.BookId = model.BookId;
            borrowedBook.UserId = model.UserId;
            borrowedBook.BorrowedDate = model.BorrowedDate;
            borrowedBook.Status = model.Status;
            borrowedBook.ReturnDate = model.ReturnDate;

             await _dbContext.BorrowedBooks.AddAsync(borrowedBook);
            var result = await _dbContext.SaveChangesAsync();
            return result;

        }

        public async ValueTask<int> DeleteAsync(int Id)
        {
            var result = await _dbContext.BorrowedBooks.FirstOrDefaultAsync(x => x.TransactionId == Id);
            _dbContext.BorrowedBooks.Remove(result);
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }

        public async ValueTask<List<BorrowedBook>> GetAllAsync()
        {
            var result = await _dbContext.BorrowedBooks.ToListAsync();
            return result;

        }

        public async ValueTask<BorrowedBook> GetByIdAsync(int Id)
        {
            var result = await _dbContext.BorrowedBooks.FirstOrDefaultAsync(x => x.TransactionId == Id);
            return result;

        }

        public async ValueTask<int> UpdateAsync(int Id, BorrowedBookDto model)
        {
            var result = await _dbContext.BorrowedBooks.FirstOrDefaultAsync(x => x.TransactionId == Id);

            BorrowedBook borrowedBook = new BorrowedBook();
            result.BookId = model.BookId;
            result.UserId = model.UserId;
            result.BorrowedDate = model.BorrowedDate;
            result.Status = model.Status;
            result.ReturnDate = model.ReturnDate;

             _dbContext.BorrowedBooks.Update(borrowedBook);
            var res = await _dbContext.SaveChangesAsync();
            return res;





        }
    }
}
