using BankckApi.Models;
using MediatR;
using BankckApi.Dtos;

namespace BankckApi.Cqrs.Queries
{
    public record GetAllAccounts: IRequest<IEnumerable<AccountDto>>;

    public record GetAccountById(int Id) : IRequest<AccountDto>;




}
