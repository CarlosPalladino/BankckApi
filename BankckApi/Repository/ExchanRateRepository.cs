using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankckApi.Repository
{
    public class ExchanRateRepository : ExChangeRateInterface
    {

        private readonly DataContext _dataContext;
        public ExchanRateRepository(DataContext context)
        {
            _dataContext = context;

        }

        public Task<bool> CreateExchangeRate(ExchangeRate exchangeRate)
        {
            _dataContext.Add(exchangeRate);
            return  Save(exchangeRate);
        }

        public Task<bool> DeleteExchangeRate(ExchangeRate exchangeRate)
        {

            _dataContext.Remove(exchangeRate);
            return Save(exchangeRate);

        }

        public  async Task<bool> ExchangeExists(int id)
        {

            return await  _dataContext.ExchangeRate.AnyAsync(e => e.Id == id);

        }

        public async Task<ExchangeRate> GetExchangeRate(int id)
        {

            return await _dataContext.ExchangeRate.FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<ICollection<ExchangeRate>> GetExchangeRates()
        {
            return await _dataContext.ExchangeRate.ToListAsync();
        }

        public async Task<bool> Save(ExchangeRate exchangeRate)
        {
            var saved = _dataContext.SaveChanges();

            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateExchangeRate(ExchangeRate exchangeRate)
        {

            _dataContext.Update(exchangeRate);
            return await Save(exchangeRate);

        }
    }
}
