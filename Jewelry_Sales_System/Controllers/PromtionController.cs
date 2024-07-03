﻿
using JewelrySalesSystem.Application.Product;
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
        [ProducesResponseType(typeof(JsonResponse<List<PromotionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetAllPromotions(
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPromotionsQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<PromotionDto>>(result)) : NotFound();
        }


        [HttpGet]
        [Route("[controller]/{id}")]
        [ProducesResponseType(typeof(JsonResponse<PromotionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetPromotionById(
            [FromRoute]string id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIDQuery(id : id), cancellationToken);
            return result != null ? Ok(new JsonResponse<PromotionDto>(result)) : NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[controller]/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        [Route("[controller]/create-random")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        [Route("[controller]/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdatePromotion(
               UpdatePromotionCommand command,
               CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeletePromotion(string id,
               CancellationToken cancellationToken = default)
        {
 
            var result = await _mediator.Send(new DeletePromotionCommand(iD : id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }

}
