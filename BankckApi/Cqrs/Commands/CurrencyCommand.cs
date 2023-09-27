using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands
{
   public record CreateCurrencyCommand(Currency Currency) : IRequest<bool>;
    public record UpdateCurrencyCommand(Currency currency) :IRequest<bool>;
    public record DeleteCurrencyCommand(Currency currency) : IRequest<bool>;




}


