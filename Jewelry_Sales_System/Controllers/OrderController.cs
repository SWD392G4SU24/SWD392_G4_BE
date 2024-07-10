
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using JewelrySalesSystem.Application.Order;
using AuthorizeAttribute = JewelrySalesSystem.Application.Common.Security.AuthorizeAttribute;
using JewelrySalesSystem.Application.Order.GetAll;
using JewelrySalesSystem.Application.Order.DeleteOrder;
using JewelrySalesSystem.Application.Order.GetByID;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Application.Role.CreateRole;
using JewelrySalesSystem.Application.Order.CustomerCreate;
using JewelrySalesSystem.Application.Order.StaffCreate;

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
        [ProducesResponseType(typeof(JsonResponse<List<OrderDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<OrderDto>>>> GetAllOrder(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllOrderQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<OrderDto>>(result)) : NotFound();
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        [ProducesResponseType(typeof(JsonResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto>> GetOrderByID(
                 [FromRoute] string id,
           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByOrderIDQuery(id : id), cancellationToken);
            return result != null ? Ok(new JsonResponse<OrderDto>(result)) : NotFound();
        }

        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteOrder([FromRoute] string id,
           CancellationToken cancellationToken)
        {
            
            var result = await _mediator.Send(new DeleteOrdercommand(id : id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPost]
        [Route("order/customer-create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateOrder(
            [FromBody] CreateOrderByCustomerCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPost("order/staff-create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateOrderByStaff(
            [FromBody] CreateOrderByStaffCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }
    }
}
