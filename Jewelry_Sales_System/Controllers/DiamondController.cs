
using JewelrySalesSystem.Application.Diamon;
using JewelrySalesSystem.Application.Diamon.GetAll;
using JewelrySalesSystem.Application.Diamond.SaveToDb;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    public class DiamondController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiamondController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("diamond/get-price")]
        public async Task<ActionResult<List<DiamondDto>>> GetDiamondPrices(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetDiamondQuery(), cancellationToken);
            return Ok(result);
        }
        [HttpPost("diamond/save-price")]
        public async Task<IActionResult> SaveDiamondPrices(CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new SaveDiamondCommand(), cancellationToken);
            return Ok(result);
        }
    }
}
