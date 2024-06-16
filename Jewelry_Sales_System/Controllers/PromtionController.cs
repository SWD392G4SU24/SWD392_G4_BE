﻿using JewelrySalesSystem.Application.Common.Security;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Application.Promotion.CreatePromotion;
using JewelrySalesSystem.Application.Promotion.GetAll;
using JewelrySalesSystem.Application.Promotion.GetById;
using JewelrySalesSystem.Application.Promotion.GetPromotion;
using JewelrySalesSystem.Application.Promotion.UpdatePromotion;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Route("GetAllPromotions")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<PromotionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetAllPromotions(
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllPromotionsQuery(), cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetPromotionById")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<PromotionDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetPromotionById(
            [FromQuery] GetByIDQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreatePromtion")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewPromotion(
           [FromBody] CreatePromotionCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [AllowAnonymous]
        [HttpPut()]
        [Route("UpdatePromotion")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdatePromotion(
               [FromBody] UpdatePromotionCommand command,
               CancellationToken cancellationToken = default)
        {
            if (command == null) return NotFound("VoucherCode is not exist");
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }

}
