using BankckApi.Models;
using MediatR;

namespace BankckApi.Cqrs.Queries
{
    public class GetById
    {



    }

    public class GetAccountByCustomerCommand : IRequest<List<Customer>>
    {
        public int CustomerId { get; set; }
    }


}
