
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
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Application.Order;

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
        [ProducesResponseType(typeof(JsonResponse<List<OrderDetailDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<OrderDetailDto>>> GetAllOrderDetails(
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllOrderDetailQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<OrderDetailDto>>(result)) : NotFound();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        [ProducesResponseType(typeof(JsonResponse<OrderDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDetailDto>> GetOrderDetailByID(
           [FromRoute] string id,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIDQuery(id : id), cancellationToken);
            return result != null ? Ok(new JsonResponse<OrderDetailDto>(result)) : NotFound();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        [ProducesResponseType(typeof(JsonResponse<OrderDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteProduct(
           [FromRoute] string id,
           CancellationToken cancellationToken)
        {
 
            var result = await _mediator.Send(new DeleteOrderDetailCommand(id : id), cancellationToken);
            if (result.Contains("thất bại"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

    }
}
