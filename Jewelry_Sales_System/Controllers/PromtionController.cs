
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Application.Promotion.CreatePromotion;
using JewelrySalesSystem.Application.Promotion.DeletePromotion;
using JewelrySalesSystem.Application.Promotion.GetAll;
using JewelrySalesSystem.Application.Promotion.GetById;
using JewelrySalesSystem.Application.Promotion.NewFolder;
using JewelrySalesSystem.Application.Promotion.UpdatePromotion;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AuthorizeAttribute = JewelrySalesSystem.Application.Common.Security.AuthorizeAttribute;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    [Authorize]
    public class PromtionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PromtionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[controller]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<PromotionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetAllPromotions(
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPromotionsQuery(), cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        [Route("[controller]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<PromotionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetPromotionById(
            string id,
            CancellationToken cancellationToken)
        {
            var query = new GetByIDQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[controller]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewPromotion(
           [FromBody] CreatePromtionCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("[controller]/random")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<string>>>> RandomNewPromotion(
           [FromBody] CreatePromotionByQuantityCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<List<string>>(result));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("[controller]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdatePromotion(string id,
               [FromBody] UpdatePromotionCommand command,
               CancellationToken cancellationToken = default)
        {
            if (id != command.ID) return BadRequest("The promotion in the request body must match the route parameter.");
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("[controller]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeletePromotion(string id,
               CancellationToken cancellationToken = default)
        {
            var command = new DeletePromotionCommand { ID = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }

}
