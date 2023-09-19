using BankckApi.Models;
using MediatR;
using BankckApi.Dtos;

namespace BankckApi.Cqrs.Queries
{
    public record GetAll : IRequest<IEnumerable<AccountDto>>;

    public record GetById(int Id) : IRequest<AccountDto>;

    public record GetAccountBycyustomer(int Id) : IRequest<CustomerDto>;



}
