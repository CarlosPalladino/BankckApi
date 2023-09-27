using BankckApi.Cqrs.Queries;
using BankckApi.Dtos;
using MediatR;

namespace BankckApi.Cqrs.Handlers.Currency
{
    public class CureencyQueryhandler
        : IRequestHandler<GettAllCurrency, IEnumerable<CurrencyDto>>,
        IRequestHandler<GettAllCurrency, CurrencyDto>
    {
        private readonly
        private readonly

        public CureencyQueryhandler()
        {
                
        }
        public Task<CurrencyDto> Handle(GettAllCurrency request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CurrencyDto>> IRequestHandler<GettAllCurrency, IEnumerable<CurrencyDto>>.Handle(GettAllCurrency request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
