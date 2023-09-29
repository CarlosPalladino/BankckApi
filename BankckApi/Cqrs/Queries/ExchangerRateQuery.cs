using BankckApi.Dtos;
using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Queries
{
    public class ExchangerRateQuery
    {

        public record ExchangeGetAll  : IRequest<IEnumerable<ExchangeRateDto>>;
        public record ExchangeGetById(int Id) : IRequest<ExchangeRateDto>;

    }
}
