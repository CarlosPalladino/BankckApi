using AutoMapper;
using BankckApi.Cqrs.Queries;
using BankckApi.Dtos;
using BankckApi.Interfaces;
using MediatR;

namespace BankckApi.Cqrs.Handlers.Customer
{
    public class CustomerQueryHandler
        : IRequestHandler<GetAllCustomer, IEnumerable<CustomerDto>>,
        IRequestHandler<GetCustomerById, CustomerDto>
    {
        private readonly IMapper _mapper;
        private readonly CustomerInterface _interface;
        public CustomerQueryHandler(IMapper mapper, CustomerInterface @interface)
        {
            _interface = @interface;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomer request, CancellationToken cancellationToken)
        {
            var Customer = await _interface.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerDto>>(Customer);
        }
        public async Task<CustomerDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            var Customer = await _interface.GetGustomer(request.Id);
            return _mapper.Map<CustomerDto>(Customer);
        }
    }
}
