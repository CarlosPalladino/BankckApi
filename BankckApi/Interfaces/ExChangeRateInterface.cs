using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface ExChangeRateInterface
    {
        ICollection<ExchangeRate> GetExchangeRates();

        ExchangeRate GetExchangeRate(int id);

        bool CreateExchangeRate(ExchangeRate exchangeRate);

        bool UpdateExchangeRate(ExchangeRate exchangeRate);

        bool DeleteExchangeRate(int id);





    }
}
