using BankckApi.Data;
using BankckApi.Models;

namespace BankckApi
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext contex)

        {
            _context = contex;
        }

        public void SeedDataContext()
        {
            if (!_context.Currency.Any())
            {
                var currencies = new List<Currency>
                {
                    new Currency{Code ="USD",Name ="Us Dollar"},
                new Currency { Code = "EUR", Name = "Euro" },

            };
                _context.Currency.AddRange(currencies);
                _context.SaveChanges();
            }
            if (!_context.Customer.Any())
            {

                var customers = new List<Customer>
                {
                    new Customer { FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                    new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" },

                };
                _context.Customer.AddRange(customers);
                _context.SaveChanges();


                if (!_context.Account.Any())
                {

                    var accounts = new List<Account>
                {


                    new Account { AccountNumber = "123456789", Balance = 1000, CreatedAt = DateTime.Now, IsLocked = false, CustomerId = customers[0].Id },
                    new Account { AccountNumber = "987654321", Balance = 1500, CreatedAt = DateTime.Now, IsLocked = false, CustomerId = customers[1].Id },
                };
                    _context.Account.AddRange(accounts);
                    _context.SaveChanges();

                    if (!_context.Transaction.Any())
                    {
                        var account1 = accounts[0]; // Obtén la cuenta de origen de la lista
                        var account2 = accounts[1]; // Obtén la cuenta de destino de la lista

                        var transactions = new List<Transaction> {


                             new Transaction
                            {
                             AccountId = account1.Id,
                             Amount = 500,
                            TransactionDate = DateTime.Now,
                                Type = TransactionType.Withdrawal
                             },
                                new Transaction
                                {
                                AccountId = account2.Id,
                                    Amount = 500,
                                    TransactionDate = DateTime.Now,
                                    Type = TransactionType.Deposit
                                }
                        };
                        _context.Transaction.AddRange(transactions);
                        _context.SaveChanges();
                    }

                }




            }
        }
    }
}


