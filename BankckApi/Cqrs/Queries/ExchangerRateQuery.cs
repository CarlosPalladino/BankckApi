using BankckApi.Dtos;
using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Queries
{
    public class ExchangerRateQuery
    {

        public record GetAll  : IRequest<IEnumerable<ExhchangeRateDto>>;
        public record GetById(int id) : IRequest<ExhchangeRateDto>;

    }
}
