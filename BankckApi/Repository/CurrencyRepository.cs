using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankckApi.Repository
{
    public class CurrencyRepository : CurrencyInterface
    {

        private readonly DataContext _Context;
        public CurrencyRepository(DataContext context)
        {
            _Context = context;
        }

        public Task<bool> CreateCurrency(Currency currency)
        {
            _Context.Add(currency);
            return Save(currency);

        }

        public async Task<bool> CurrencyExits(int Id)
        {
            return  await _Context.Currency.AnyAsync(c => c.Id == Id);
        }

        public Task<bool> DeleteCurrency(Currency currency)
        {
            _Context.Remove(currency);
            return Save(currency);

        }

        public async Task<ICollection<Currency>> GetCurrencies()
        {
            return await _Context.Currency.ToListAsync();
        }



        public async Task<Currency> GetCurrency(int Id)
        {
            return await _Context.Currency.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<bool> Save(Currency currency)
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateCurrency(Currency currency)
        {
            _Context.Update(currency);
            return await Save(currency);

        }
    }
}
