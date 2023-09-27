using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface CurrencyInterface
    {

        Task<ICollection<Currency>> GetCurrencies();


        Task<Currency> GetCurrency(int Id);


        Task<bool> CurrencyExits(int Id);

        Task<bool> Save(Currency currency);

        Task<bool> CreateCurrency(Currency currency);

        Task<bool> UpdateCurrency(Currency Currency);
        Task<bool> DeleteCurrency(Currency Currency);


    }
}
