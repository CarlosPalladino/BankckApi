using BankckApi.Dtos;
using BankckApi.Interfaces;
using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands
{
    public record CreateAccountCommand(Account Account) : IRequest<bool>;

    public record UpdateAccountCommand(Account Account) : IRequest<bool>;

    public record DeleteAccountCommand(Account Account) : IRequest<bool>;



}