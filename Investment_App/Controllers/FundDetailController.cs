using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Investment_App.Commands;
using Investment_App.Queries;
using Investment_App.Model;

namespace Investment_App.Controllers
{
    [Route("api/[controller]")]
    public class FundDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FundDetailController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllFundDetailsQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateFundDetail commands)
        {

            var command = new CreateFund.Command
            {
                fundDetails = commands
            };
            try
            {
                if (command.fundDetails.FundName == null || command.fundDetails.Description == null)
                {
                    return BadRequest();
                }

                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFundCommand.Command
            {
                ID = id
            };
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]CreateOrUpdateFundDetail commands)
        {
            var command = new UpdateFund.Command
            {
                fundDetails = commands
            };
            try
            {
                if (id != command.fundDetails.ID)
                {
                    return BadRequest();
                }
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
