
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using JewelrySalesSystem.Application.Order;
using AuthorizeAttribute = JewelrySalesSystem.Application.Common.Security.AuthorizeAttribute;
using JewelrySalesSystem.Application.Order.GetAll;
using JewelrySalesSystem.Application.Order.DeleteOrder;
using JewelrySalesSystem.Application.Order.GetByID;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[controller]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders(
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto>> GetOrderByID(
                 string id,
           CancellationToken cancellationToken)
        {
            var query = new GetByIDQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }



        [AllowAnonymous]
        [HttpDelete]
        [Route("[controller]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteOrder( string id,
           CancellationToken cancellationToken)
        {
            var command = new DeleteOrdercommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
