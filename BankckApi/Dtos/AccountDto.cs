using BankckApi.Models;

namespace BankckApi.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
        public int   ? CustomerId { get; set; }



    }
}
