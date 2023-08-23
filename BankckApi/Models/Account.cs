namespace BankckApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsLocked { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
