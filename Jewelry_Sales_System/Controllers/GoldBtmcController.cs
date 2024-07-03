using JewelrySalesSystem.Application.GoldBtmc;
using JewelrySalesSystem.Application.GoldBtmc.GetGoldPrice;
using JewelrySalesSystem.Application.GoldBtmc.SaveToDb;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Entities.Configured;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    //[Authorize]
    public class GoldBtmcController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoldBtmcController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("goldBtmc/get-price")]
        public async Task<ActionResult<List<GoldDto>>> GetGoldPrices(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetGoldPriceQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPost("goldBtmc/save-price")]
        public async Task<IActionResult> SaveGoldPrices(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new SaveGoldCommand(), cancellationToken);
            return Ok(result);
        }
    }
}
