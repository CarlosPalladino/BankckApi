using BankckApi.Cqrs.Commands;
using MediatR;

namespace BankckApi.Cqrs.Handlers.Currency
{
    public class CurrencyCommandHandler
        : IRequestHandler<CreateCurrencyCommand, bool>,
            IRequestHandler<UpdateCurrencyCommand, bool>,
        IRequestHandler<DeleteCurrencyCommand, bool>
    {
        private readonly
        private readonly

        public CurrencyCommandHandler()
        {
                
        }
        public Task<bool> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
