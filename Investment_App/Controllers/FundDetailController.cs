using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Investment_App.Commands;
using Investment_App.Queries;
using Investment_App.Model;
using Investment_App.Authorization;

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
            //var claims = User.GetEmailClaimValue();
            var command = new GetAllFundDetailsQuery.Command();
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundDetailByID(int id)
        {
            var command = new GetFundDetailByIDQuery.Command
            {
                ID = id
            };
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                if (command.fundDetails.FundName == null || command.fundDetails.Description == null || command.fundDetails.InvestorName == null ||
                    command.fundDetails.InvestedAmount < 0 || command.fundDetails.CurrentValueOfInvestedAmount < 0)
                {
                    return BadRequest();
                }

                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                return BadRequest(ex);
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
                return BadRequest(ex);
            }
        }
    }
}
