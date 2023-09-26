using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankckApi.Repository
{
    public class CustomerRepository : CustomerInterface
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            context = _context;
        }
        public Task<bool> CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save(customer);
        }

        public bool CustomerExits(int id)
        {
            return _context.Customer.Where(c => c.Id == id).Any();
        }

        public Task<bool> DeleteCustomer(Customer customer)
        {
            _context.Customer.Remove(customer);
            return Save(customer);

        }

        //public async Task<ICollection<Account>> GetAccoutByCustomer(int CustomerId)
        //{
        //    return await _context.Customer.FindAsync
        //}

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }


        public async Task<Customer> GetGustomer(int id)
        {
            return  await _context.Customer.FirstOrDefaultAsync(c => c.Id == id);
        }

        public  async Task<bool> Save(Customer customer)
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;

        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save(customer);

        }
    }
}
