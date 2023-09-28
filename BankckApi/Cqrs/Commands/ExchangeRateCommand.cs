using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands
{
    public class ExchangeRateCommand
    {
        public record CreateCommand(ExchangeRate change) : IRequest<bool>;
        public record UpdateCommand(ExchangeRate change) : IRequest<bool>;
        public record DeleteCommand(ExchangeRate change) : IRequest<bool>;

    }
}
