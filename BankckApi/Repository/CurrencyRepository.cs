using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;

namespace BankckApi.Repository
{
    public class CurrencyRepository : CurrencyInterface
    {

        private readonly DataContext _Context;
        public CurrencyRepository(DataContext context)
        {
            context = _Context;
        }

        public bool CreateCurrency(Currency currency)
        {
            _Context.Add(currency);
            return Save(currency);

        }

        public bool CurrencyExits(int Id)
        {
            return _Context.Currency.Any(c => c.Id == Id);
        }

        public bool DeleteCurrency(Currency currency)
        {
            _Context.Remove(currency);
            return Save(currency);

        }

        public ICollection<Currency> GetCurrencies()
        {
            return _Context.Currency.ToList();
        }



        public Currency GetCurrency(int Id)
        {
            return _Context.Currency.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save(Currency currency)
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCurrency(Currency currency)
        {
            _Context.Update(currency);
            return Save(currency);

        }
    }
}
