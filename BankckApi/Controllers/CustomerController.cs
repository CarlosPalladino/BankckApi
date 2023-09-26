using Microsoft.AspNetCore.Mvc;
using MediatR;
using BankckApi.Interfaces;
using BankckApi.Models;
using Microsoft.Identity.Client;
using BankckApi.Dtos;
using System.Collections.Generic;
using BankckApi.Cqrs.Queries;
using AutoMapper;
using BankckApi.Cqrs.Commands;
using static BankckApi.Cqrs.Commands.CustomerCommand;

namespace BankckApi.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly CustomerInterface _customer;
        public CustomerController(IMapper mapper, IMediator mediator, CustomerInterface customer)
        {
            _mapper = mapper;
            _mediator = mediator;
            _customer = customer;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetCustomers()
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var customer = new GetAllCustomer();

            var result = await _mediator.Send(customer);
            return Ok();
        }

        [HttpGet("Customers/{CustomerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetCustomer(int customerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = new GetCustomerById(customerId);
            var result = await _mediator.Send(account);

            return Ok();

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto createCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var CustomerMap = _mapper.Map<Customer>(createCustomer);

            var Account = new CreateCustomerCommand(CustomerMap);

            var result = await _mediator.Send(Account);

            if (result)
                return Ok("Customer creado");
            else
                return BadRequest("no se pudo crear");


        }
        [HttpPut("{customerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]


        public async Task<IActionResult> UpdateCustomer(int CustomerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var CustomerMao = _mapper.Map<Customer>(CustomerId);

            var Customer = new UpdateCustomerCommand(CustomerMao);

            var result = await _mediator.Send(Customer);
            if (result)
                return Ok("Actualizado correctamente");
            else
                return BadRequest("No se pudo actualiar");
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Deletecustomer(int CustomerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var customer = await _customer.GetGustomer(CustomerId);

            var CustomerToDelete = new DeleteCustomerCommand(customer);

            var result = await _mediator.Send(CustomerToDelete);

            if (result)
                return Ok("Customer eliminado");
            else return BadRequest("no se pudo eliminar");
        }

    }
}
