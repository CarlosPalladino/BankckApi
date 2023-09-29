using AutoMapper;
using BankckApi.Dtos;
using BankckApi.Interfaces;
using MediatR;
using static BankckApi.Cqrs.Queries.ExchangerRateQuery;

namespace BankckApi.Cqrs.Handlers.ExChangeRate
{
    public class ExchangeRateQueryHandler
       : IRequestHandler<ExchangeGetAll, IEnumerable<ExchangeRateDto>>,
           IRequestHandler<ExchangeGetById, ExchangeRateDto>

    {

        private readonly IMapper _mapper;
        private readonly ExChangeRateInterface _interface;

        public ExchangeRateQueryHandler(IMapper mapper, ExChangeRateInterface @interface)
        {
            _mapper = mapper;
            _interface = @interface;
        }

        public async Task<IEnumerable<ExchangeRateDto>> Handle(ExchangeGetAll request, CancellationToken cancellationToken)
        {
            var exchange = await _interface.GetExchangeRates();
            return _mapper.Map<IEnumerable<ExchangeRateDto>>(exchange);

        }
        public async Task<ExchangeRateDto> Handle(ExchangeGetById request, CancellationToken cancellationToken)
        {
            var exchange = await _interface.GetExchangeRate(request.Id);

            return _mapper.Map<ExchangeRateDto>(exchange);
        }

    }
}
