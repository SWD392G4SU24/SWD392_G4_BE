using JewelrySalesSystem.Application.GoldBtmc;
using JewelrySalesSystem.Application.GoldBtmc.GetGoldPrice;
using JewelrySalesSystem.Application.GoldBtmc.SaveToDb;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Entities.Configured;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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

        [HttpPost("goldBtmc/save-today-price")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> SaveGoldPrices(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new SaveGoldCommand(), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
