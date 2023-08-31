using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;

namespace BankckApi.Repository
{
    public class TransactionRepository : TransactionInterface
    {
        private readonly DataContext _context
        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTransaction(Transaction transaction)
        {

            _context.Add(transaction);
            return Save(transaction);
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            _context.Remove(transaction);
            return Save(transaction);
        }

        public Transaction GetTransaction(int Id)
        {
            return _context.Transaction.Where(t => t.Id == Id).FirstOrDefault();
        }

        public ICollection<Account> GetTransactionByAccount(int AccountId)
        {
            return _context.Account.Where(a => AccountId == a.Id).Select(a => a.Transactions).FirstOrDefault();
        }

        public ICollection<Transaction> GetTransactions()
        {
            return _context.Transaction.ToList();

        }

        public bool Save(Transaction transaction)
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransactionExits(Transaction transaction)
        {

            return _context.Transaction.Any();
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            _context.Transaction.Update(transaction);
            return Save(transaction);
        }
    }
}
