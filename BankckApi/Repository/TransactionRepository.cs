using BankckApi.Interfaces;
using BankckApi.Models;

namespace BankckApi.Repository
{
    public class TransactionRepository : TransactionInterface
    {
        public bool CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransaction(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Account> GetTransactionByAccount(int AccountId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public bool TransactionExits(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
