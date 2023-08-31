using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface TransactionInterface
    {

        ICollection<Transaction> GetTransactions();


        Transaction GetTransaction(int Id);

        ICollection<Account> GetTransactionByAccount(int AccountId);

        bool Save(Transaction transaction);

        bool TransactionExits(Transaction transaction);

        bool CreateTransaction(Transaction transaction);

        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(Transaction transaction);

    }
}
