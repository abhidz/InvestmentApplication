using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Investment_App.Commands;
using Investment_App.Queries;

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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFundCommand command)
        {
            try
            {
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
            try
            {
                var result = await _mediator.Send(new DeleteFundCommand { ID = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFundCommand command)
        {
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
