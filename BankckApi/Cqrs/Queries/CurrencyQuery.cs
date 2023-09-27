using BankckApi.Dtos;
using MediatR;

namespace BankckApi.Cqrs.Queries
{
  public record GettAllCurrency :IRequest<IEnumerable<CurrencyDto>>;
  public record GettCurrencyById(int Id) :IRequest<CurrencyDto>;
}
