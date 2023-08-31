using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;

namespace BankckApi.Repository
{
    public class ExchanRateRepository : ExChangeRateInterface
    {

        private readonly DataContext _dataContext;
        public ExchanRateRepository(DataContext context)
        {
            _dataContext = context;

        }

        public bool CreateExchangeRate(ExchangeRate exchangeRate)
        {
            _dataContext.Add(exchangeRate);
            return Save(exchangeRate);
        }

        public bool DeleteExchangeRate(ExchangeRate exchangeRate)
        {

            _dataContext.Remove(exchangeRate);
            return Save(exchangeRate);

        }

        public bool ExchangeExists(int id)
        {

            return _dataContext.ExchangeRate.Any(e => e.Id == id);

        }

        public ExchangeRate GetExchangeRate(int id)
        {

            return _dataContext.ExchangeRate.Where(e => e.Id == id).FirstOrDefault();

        }

        public ICollection<ExchangeRate> GetExchangeRates()
        {
            return _dataContext.ExchangeRate.ToList();
        }

        public bool Save(ExchangeRate exchangeRate)
        {
            var saved = _dataContext.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateExchangeRate(ExchangeRate exchangeRate)
        {

            _dataContext.Update(exchangeRate);
            return Save(exchangeRate);

        }
    }
}
