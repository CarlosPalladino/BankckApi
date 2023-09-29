using AutoMapper;
using BankckApi.Dtos;
using BankckApi.Interfaces;
using BankckApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BankckApi.Cqrs.Commands.ExchangeRateCommand;
using static BankckApi.Cqrs.Queries.ExchangerRateQuery;

namespace BankckApi.Controllers
{
    [ApiController]
    [Route("api/ExchangeRate")]
    public class ExhcangeRateController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ExChangeRateInterface _interface;

        public ExhcangeRateController(IMediator mediator, IMapper mapper, ExChangeRateInterface @interface)
        {
            _mapper = mapper;
            _mediator = mediator;
            _interface = @interface;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetAllExchange()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Exchange = new ExchangeGetAll();

            var result = await _mediator.Send(Exchange);
            return Ok(result);
        }
        [HttpGet("{ExchangeRateId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetChangeRateById(int ExchangeRateId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var exchangeRateById = new ExchangeGetById(ExchangeRateId);

            var rs = await _mediator.Send(exchangeRateById);


            return Ok(rs);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> CreateExchangeRate([FromBody] ExchangeRateDto changeRate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var create = _mapper.Map<ExchangeRate>(changeRate);

            var createEx = new ExchangeCreateCommand(create);


            var rs = await _mediator.Send(createEx);
            return Ok("Exchange Creado");
        }
        [HttpPut("{ExchangeRateId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> UpdateExchange(int ExchangeRateId, [FromBody] ExchangeRateDto changeRate)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ExchangerMap = _mapper.Map<ExchangeRate>(changeRate);

            var ExchangeUpdate = new ExchangeUpdateCommand(ExchangerMap);

            var rs = await _mediator.Send(ExchangeUpdate);

            if (rs)
                return Ok("Exchange Actualizado");
            else
                return BadRequest(" no se puido actualizar ");
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> DeleteExchange(int ChandeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exchangeRate = await _interface.GetExchangeRate(ChandeId);

            var ExchangeRateToDelete = new ExchangeDeleteCommand(exchangeRate);

            var rs = await _mediator.Send(ExchangeRateToDelete);
            if (rs)
                return Ok("Exchange Eliminando");
            else
                return BadRequest("No se pudo eliminar");

        }







    }
}
