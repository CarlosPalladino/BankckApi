using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface ExChangeRateInterface
    {
        ICollection<ExchangeRate> GetExchangeRates();

        ExchangeRate GetExchangeRate(int id);

        bool ExchangeExists(int id);

        bool Save(ExchangeRate exchangeRate);

        bool CreateExchangeRate(ExchangeRate exchangeRate);

        bool UpdateExchangeRate(ExchangeRate exchangeRate);

        bool DeleteExchangeRate(ExchangeRate exchangeRate);





    }
}
