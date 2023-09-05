using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands.Account
{
    public class AccountCommand : IRequest<bool>
    {
        public string AccountNumber { get; set; }
        public decimal InitialBalance { get; set; }
        public int CustomerId
        {
            get; set;
        }
    }
    public class ReadAccount : IRequest<ReadAccount>
    {
        public int AccountId { get; set; }

    }
    public class UpdateAccount : IRequest<bool>
    {
        public int AccountId { get; set; }
        public string NewAccountNumber { get; set; }
        public decimal NewBalanace { get; set; }

    }
    public class DeleteAccountCommand : IRequest<bool>
    {
        public int AccountId { get; set; }

    }

    public class GetAccountByCustomerCommand : IRequest<List<Customer>>
    {
        public int CustomerId { get; set; }
    }



}