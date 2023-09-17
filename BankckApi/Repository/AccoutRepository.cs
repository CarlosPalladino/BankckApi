using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankckApi.Repository
{
    public class AccoutRepository : AccoutInterface
    {
        private readonly DataContext _context;

        public AccoutRepository(DataContext context)
        {

            _context = context;
        }

        public async Task<bool> AccoutExits(int Id)
        {
            return await _context.Account.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> CreateAccout(Account account)
        {

            _context.Add(account);
            return await Save(account);
        }
        public async Task<bool> DeleteAccout(Account account)
        {
            _context.Remove(account);
            return await Save(account);
        }

        public async Task<bool> Save(Account account)
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateAccout(Account account)
        {
            _context.Update(account);
            return await Save(account);

        }
        public async Task<Account> GetAccount(int Id)
        {
            return await _context.Account.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<ICollection<Account>> GetAccounts()
        {
            return await _context.Account.ToListAsync();
        }

        public  async Task<ICollection<Account>> GetAccoutByCustomer(int CustomerId)
        {
            return await _context.Customer
                          .Where(c => CustomerId == c.Id)
                          .SelectMany(c => c.Accounts)
                          .ToListAsync();
        }

   
    }
}
