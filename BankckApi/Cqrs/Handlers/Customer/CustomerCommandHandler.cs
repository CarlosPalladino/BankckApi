using MediatR;
using BankckApi.Cqrs.Commands;
using static BankckApi.Cqrs.Commands.CustomerCommand;
using BankckApi.Interfaces;
using AutoMapper;

namespace BankckApi.Cqrs.Handlers.Customer
{
    public class CustomerCommandHandler
        : IRequestHandler<CreateCustomerCommand, bool>,
          IRequestHandler<UpdateCustomerCommand, bool>,
          IRequestHandler<DeleteCustomerCommand, bool>


    {
        private readonly CustomerInterface _interface;

        public CustomerCommandHandler(CustomerInterface @interface)
        {
            _interface = @interface;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _interface.CreateCustomer(request.Customer);
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _interface.UpdateCustomer(request.Customer);
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _interface.DeleteCustomer(request.Customer);
        }


    }
}
