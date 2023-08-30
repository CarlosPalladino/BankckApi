using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface CurrencyInterface
    {

        ICollection<Currency> GetCurrencies();


        Currency GetCurrency(int Id);


        bool CurrencyExits(int Id);

        bool Save(Currency currency);

        bool CreateCurrency(Currency currency);

        bool UpdateCurrency(Currency currency);
        bool DeleteCurrency(Currency currency);


    }
}
