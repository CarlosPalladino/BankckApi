using BankckApi.Dtos;
using MediatR;
using BankckApi.Models;

namespace BankckApi.Cqrs.Queries
{

    public record GetAllCustomer : IRequest<IEnumerable<CustomerDto>>;
    public record GetCustomerById(int Id) : IRequest<CustomerDto>;

    //public record GetAccountBycyustomer(int Id) : IRequest<CustomerDto>;




}
