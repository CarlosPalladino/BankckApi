using BankckApi.Data;
using BankckApi.Dtos;
using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface AccoutInterface
    {
        Task<ICollection<Account>> GetAccounts();

        Task<Account> GetAccount(int Id);

        Task<ICollection<Account>> GetAccoutByCustomer(int CustomerId);

        Task<bool> AccoutExits(int Id);
        Task<bool> CreateAccout(Account account);
        Task<bool> UpdateAccout(Account account);

        Task<bool> DeleteAccout(Account account);

        Task<bool> Save(Account account);
    }
}
