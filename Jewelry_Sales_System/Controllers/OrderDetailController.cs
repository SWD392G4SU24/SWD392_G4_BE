
using JewelrySalesSystem.Application.OrderDetail;
using JewelrySalesSystem.Application.OrderDetail.Delete;
using JewelrySalesSystem.Application.OrderDetail.GetAll;
using JewelrySalesSystem.Application.OrderDetail.GetByID;
using MediatR;
using AuthorizeAttribute = JewelrySalesSystem.Application.Common.Security.AuthorizeAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderDetailController : ControllerBase
   
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[controller]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<OrderDetailDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetAllOrderDetails(
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderDetailQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderDetailDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDetailDto>> GetOrderDetailByID(
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
        public async Task<ActionResult<JsonResponse<string>>> DeleteProduct(
            string id,
           CancellationToken cancellationToken)
        {
            var command = new DeleteOrderDetailCommand { Id  = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

    }
}
