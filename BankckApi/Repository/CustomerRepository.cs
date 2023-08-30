using BankckApi.Data;
using BankckApi.Interfaces;
using BankckApi.Models;

namespace BankckApi.Repository
{
    public class CustomerRepository : CustomerInterface
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            context = _context;
        }
        public bool CreateCustomer(Customer customer)
        {
            _context.SaveChanges(customer);
            return Save(customer);
        }

        public bool CustomerExits(int id)
        {
            return _context.Customer.Where(c => c.Id == id).Any();
        }

        public bool DeleteCustomer(Customer customer)
        {
            _context.Customer.Remove(customer);
            return Save(customer);

        }

        public ICollection<Account> GetAccoutByCustomer(int AccoutId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }


        public Customer GetGustomer(int id)
        {
            return _context.Customer.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save(Customer customer)
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;

        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save(customer);

        }
    }
}
