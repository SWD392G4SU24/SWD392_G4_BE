using AutoMapper;
using JewelrySalesSystem.Application.Role.CreateRole;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Jewelry_Sales_System.API.Controllers
{
    [Authorize]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateRole(
            [FromBody] CreateRoleCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
