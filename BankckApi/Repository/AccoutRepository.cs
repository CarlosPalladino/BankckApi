using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;
namespace BankckApi.Repository
{
    public class AccoutRepository : AccoutInterface
    {
        private readonly DataContext _context;

        public AccoutRepository(DataContext context)
        {

            _context = context;
        }

        public bool AccoutExits(int Id)
        {
            return _context.Account.Any(a => a.Id == Id);
        }

        public bool CreateAccout(Account account)
        {

            _context.Add(account);
            return Save(account);
        }
        public bool DeleteAccout(Account account)
        {
            _context.Remove(account);
            return Save(account);
        }

        public Account GetAccount(int Id)
        {
            return _context.Account.Where(a => a.Id == Id).FirstOrDefault();
        }

        public ICollection<Account> GetAccounts()
        {
            return _context.Account.ToList();
        }

        public ICollection<Customer> GetAccoutByCustomer(int CustomerId)
        {
            return _context.Customer.Where(c => CustomerId == c.Id).Select(c => c.Accounts).ToList();
        }

        public bool Save(Account account)
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAccout(Account account)
        {
            _context.Update(account);
            return Save(account);

        }



    }
}
