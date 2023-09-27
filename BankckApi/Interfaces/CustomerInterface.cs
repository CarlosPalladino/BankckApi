using BankckApi.Models;

namespace BankckApi.Interfaces
{
    public interface CustomerInterface
    {

        Task<ICollection<Customer>> GetCustomers();

        Task<Customer> GetGustomer(int id);

        Task<bool> Save(Customer customer);

        //Task<ICollection<Account>> GetAccoutByCustomer(int CustomerId);

        bool CustomerExits(int id);

        Task<bool> CreateCustomer(Customer customer);


        Task<bool> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(Customer customer);


    }
}
