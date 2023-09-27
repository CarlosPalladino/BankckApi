using AutoMapper;
using BankckApi.Cqrs.Commands;
using BankckApi.Cqrs.Queries;
using BankckApi.Dtos;
using BankckApi.Interfaces;
using BankckApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankckApi.Controllers
{
    [Route("api/Currency")]
    [ApiController]
    public class CurrencyController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly CurrencyInterface _currency;
        public CurrencyController(IMapper mapper, CurrencyInterface currency, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _currency = currency;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetCurrencies()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var GetCurrencies = new GettAllCurrency();
            var result =  await _mediator.Send(GetCurrencies);

            return Ok(result);
        }
        [HttpGet("{currencyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCurrency(int currencyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var GetCurrencyById = new GettCurrencyById(currencyId);
            var result =  await _mediator.Send(GetCurrencyById);
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyDto currency)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var CurrencyMap = _mapper.Map<Currency>(currency);
            var CreateCurrency = new CreateCurrencyCommand(CurrencyMap);
            var result = await _mediator.Send(CreateCurrency);
            if (result)
                return Ok("Currency Creado");
            else return
                    BadRequest("no se pudo crear el currency");
        }
        [HttpPut("{CurrencyId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCurrency(int CurrencyId, [FromBody] CurrencyDto UpdateCurrency)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var CurrencyMap = _mapper.Map<Currency>(UpdateCurrency);
            var Update = new UpdateCurrencyCommand(CurrencyMap);

            var result = await _mediator.Send(Update);
            if (result)
                return Ok("Currency Actualizado");
            else
                return BadRequest("No se pudo Actualizar currency");
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCurrency(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Currency =  await _currency.GetCurrency(id);

            var CurrencyToDelete = new DeleteCurrencyCommand(Currency);
            var result = await _mediator.Send(CurrencyToDelete);
            if (result)
                return Ok("currency eliminado");
            else
                return BadRequest("no se pudo eliminar");

        }



    }
}
