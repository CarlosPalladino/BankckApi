using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface CustomerInterface
    {

        ICollection<Customer> GetCustomers();

        Customer GetGustomer(int id);


        ICollection<Account> GetAccoutByCustomer(int AccoutId);

        bool CustomerExits(int id);

        bool CreateCustomer(Customer customer);


        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(Customer customer);


    }
}
