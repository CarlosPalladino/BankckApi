using BankckApi.Dtos;
using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands.Account
{
    public record CreateAccountCommand(int Id, string AccountNumber, Decimal balance, bool IsLocked) 
        : IRequest<AccountDto>;

    
    public record UpdateAccount(int Id,string AccoutNumber,decimal balance,bool IsLocked) 
        : IRequest<AccountDto>;

    public record DeleteAccountCommand(int Id) : IRequest<bool>;



}