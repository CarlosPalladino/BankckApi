using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands.Account
{
    public class CreateAccountCommand : IRequest<bool>
    {
        public string AccountNumber { get; set; }
        public decimal InitialBalance { get; set; }
        public int CustomerId
        {
            get; set;
        }
    }

    
    public record UpdateAccount(int Id,string AccoutNumber,decimal balance,bool IsLocked) 
        : IRequest<bool>
    {
        public int AccountId { get; set; }
        public string NewAccountNumber { get; set; }
        public decimal NewBalanace { get; set; }

    }
    public record DeleteAccountCommand(int Id) : IRequest<bool>;



}