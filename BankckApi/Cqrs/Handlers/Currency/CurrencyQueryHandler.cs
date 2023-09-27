using AutoMapper;
using BankckApi.Cqrs.Queries;
using BankckApi.Dtos;
using BankckApi.Interfaces;
using MediatR;

namespace BankckApi.Cqrs.Handlers.Currency
{
    public class CurrencyQueryHandler
        : IRequestHandler<GettAllCurrency, IEnumerable<CurrencyDto>>,
        IRequestHandler<GettCurrencyById, CurrencyDto>
    {
        private readonly CurrencyInterface _interface;
        private readonly IMapper _mapper;

        public CurrencyQueryHandler(CurrencyInterface @interface, IMapper mapper)
        {
            _interface = @interface;
            _mapper = mapper;
        }


        public async Task<CurrencyDto> Handle(GettCurrencyById request, CancellationToken cancellationToken)
        {
            var currency = await _interface.GetCurrency(request.Id);
            return _mapper.Map<CurrencyDto>(currency);

        }

        public async Task<IEnumerable<CurrencyDto>> Handle(GettAllCurrency request, CancellationToken cancellationToken)
        {
            var currrency = await _interface.GetCurrencies();
            return _mapper.Map<IEnumerable<CurrencyDto>>(currrency);
        }
    }
}
