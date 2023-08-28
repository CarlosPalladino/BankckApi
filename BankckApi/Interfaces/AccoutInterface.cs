using BankckApi.Data;
using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface AccoutInterface
    {
        ICollection<Account> GetAccounts();

        Account GetAccount(int Id);

        ICollection<Customer> GetAccoutByCustomer(int CustomerId);

        Account AccoutExits(int Id);
        bool CreateAccout(Account account);
        bool UpdateAccout(Account account);

        bool DeleteAccout(Account account);



    }
}
