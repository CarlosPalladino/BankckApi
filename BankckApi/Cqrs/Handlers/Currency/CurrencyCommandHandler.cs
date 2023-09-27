using AutoMapper;
using BankckApi.Cqrs.Commands;
using BankckApi.Interfaces;
using MediatR;

namespace BankckApi.Cqrs.Handlers.Currency
{
    public class CurrencyCommandHandler
        : IRequestHandler<CreateCurrencyCommand, bool>,
            IRequestHandler<UpdateCurrencyCommand, bool>,
        IRequestHandler<DeleteCurrencyCommand, bool>
    {
        private readonly CurrencyInterface _interface;
        private readonly IMapper _mapper;

        public CurrencyCommandHandler(CurrencyInterface @interface, IMapper mapper)
        {
            _interface = @interface;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _interface.CreateCurrency(request.Currency);

        }

        public async Task<bool> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _interface.UpdateCurrency(request.currency);

        }

        public async Task<bool> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _interface.DeleteCurrency(request.currency);
        }
    }
}
