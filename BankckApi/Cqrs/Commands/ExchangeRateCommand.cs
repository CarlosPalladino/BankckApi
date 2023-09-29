using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Commands
{
    public class ExchangeRateCommand
    {

        public record ExchangeCreateCommand(ExchangeRate change) : IRequest<bool>;
        public record ExchangeUpdateCommand(ExchangeRate change) : IRequest<bool>;
        public record ExchangeDeleteCommand(ExchangeRate change) : IRequest<bool>;

    }
}
