using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface ExChangeRateInterface
    {
        Task<ICollection<ExchangeRate>> GetExchangeRates();

        Task<ExchangeRate> GetExchangeRate(int id);

        Task<bool> ExchangeExists(int id);

        Task<bool> Save(ExchangeRate exchangeRate);

        Task<bool> CreateExchangeRate(ExchangeRate exchangeRate);

        Task<bool> UpdateExchangeRate(ExchangeRate exchangeRate);

        Task<bool> DeleteExchangeRate(ExchangeRate exchangeRate);





    }
}
