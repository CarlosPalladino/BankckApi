using MediatR;
using BankckApi.Models;



namespace BankckApi.Cqrs.Commands
{
    public class CustomerCommand
    {
        public record CreateCustomerCommand(Customer Customer) : IRequest<bool>;
        public record UpdateCustomerCommand(Customer Customer) : IRequest<bool>;
        public record DeleteCustomerCommand(Customer Customer) : IRequest<bool>;
    }
}
