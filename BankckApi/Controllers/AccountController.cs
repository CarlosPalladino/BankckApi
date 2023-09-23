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

namespace BankckApi.Controllers
{

    [Route("api/Accounts")]
    [ApiController]

    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private readonly AccoutInterface _interface;

        public AccountController(IMediator mediator, AccoutInterface @interface,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _interface = @interface;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetAccounts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var acccounts = _interface.GetAccounts();
             var account = new GetAll();

            var result =  await _mediator.Send(account);
            return Ok(result);
        }
        [HttpGet("{accoutId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAccout(int accoutId)
        {
            if (!await _interface.AccoutExits(accoutId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var account = _interface.GetAccount(Id);
            var account = new GetById(accoutId);
            var result = await _mediator.Send(account);
            return Ok(result);
        }
        [HttpGet("Account/{customerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetAccountByCustomer(int id)
        {
            if (!await _interface.AccoutExits(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var account = _interface.GetAccoutByCustomer(id);
            var result  =  await _mediator.Send(account);
            return Ok(result);

        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> CreateAccount([FromBody] AccountDto accountCreate)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accounts = await _interface.GetAccounts();

            var account = accounts.Where(a => a.AccountNumber.Trim().ToUpper() == accountCreate.AccountNumber
                    .TrimEnd().ToUpper()).FirstOrDefault();

            if (account != null)
            {
                ModelState.AddModelError("", "account alreeady exits");
                return StatusCode(422, ModelState);
            }

            var AccoutMap = _mapper.Map<Account>(accountCreate);
            
            var accountToCreate = new CreateAccountCommand(AccoutMap);
            var result = await  _mediator.Send(accountToCreate);
            //var CreateAccount =  _interface.CreateAccout(accountCreate);
            if (result)
                return Ok("account created");
            else
                return BadRequest("no se puede crear el account");
        }

        [HttpPut("{accountId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> UpdateAccount(int accountId, [FromBody] AccountDto UpdateAccount)
        {
            if (!await _interface.AccoutExits(accountId))
            {
                return NotFound();
            }
            if (UpdateAccount == null)
            {
                return BadRequest(ModelState);
            }
            if (accountId != UpdateAccount.Id)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var account = new UpdateAccountCommand(UpdateAccount);
            //var result = _mediator.Send(account);

            return Ok("Update Success");

        }


        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(300)]

        public async Task<IActionResult> DeleteAccount(int accountId)
        {
            if (!await _interface.AccoutExits(accountId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var accountToDelete = await _interface.GetAccount(accountId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (!await _interface.DeleteAccout(accountToDelete))
            {
                ModelState.AddModelError("", "something happen went wrong deleting country");
            }

            return Ok("Delete succes");
        }
    }

}
