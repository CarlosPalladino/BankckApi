using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface CurrencyInterface
    {

        ICollection<Currency> GetCurrencies();


        Currency GetCurrency(int currency);

        ICollection<Currency> GetCurrenciesById(int Id);

        Currency CurrencyExits(int currency);

        bool CreateCurrency(Currency currency);

        bool UpdateCurrency(Currency currency);
        bool DeleteCurrency(Currency currency);


    }
}
