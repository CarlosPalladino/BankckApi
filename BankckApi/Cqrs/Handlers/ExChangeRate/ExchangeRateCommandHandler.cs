using AutoMapper;
using BankckApi.Interfaces;
using MediatR;
using static BankckApi.Cqrs.Commands.ExchangeRateCommand;

namespace BankckApi.Cqrs.Handlers.ExChangeRate
{
    public class ExchangeRateCommandHandler
        : IRequestHandler<ExchangeCreateCommand, bool>,
        IRequestHandler<ExchangeUpdateCommand, bool>,
        IRequestHandler<ExchangeDeleteCommand, bool>
    {
        private readonly ExChangeRateInterface _interface;

        public ExchangeRateCommandHandler(  ExChangeRateInterface @interface)
        {
            _interface = @interface;
        }

        public async Task<bool> Handle(ExchangeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _interface.CreateExchangeRate(request.change);
         
        }

        public async Task<bool> Handle(ExchangeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _interface.UpdateExchangeRate(request.change);
        }

        public async Task<bool> Handle(ExchangeDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _interface.DeleteExchangeRate(request.change);
        }
    }
}
