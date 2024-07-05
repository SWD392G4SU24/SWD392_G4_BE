
using JewelrySalesSystem.Application.Diamon;
using JewelrySalesSystem.Application.Diamon.GetAll;
using JewelrySalesSystem.Application.Diamond.SaveToDb;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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
        [HttpPost("diamond/save-today-price")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> SaveDiamondPrices(CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new SaveDiamondCommand(), cancellationToken);
            if (result.Contains("thất bại"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }
    }
}
