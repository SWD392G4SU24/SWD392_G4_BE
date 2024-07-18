using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.FilterRevenue;
using JewelrySalesSystem.Application.Counter;
using JewelrySalesSystem.Application.Users;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using JewelrySalesSystem.Application.Users.CurrrentUser;
using JewelrySalesSystem.Application.Users.FilterUser;
using JewelrySalesSystem.Application.Users.GetByPagination;
using JewelrySalesSystem.Application.Users.GetCustomerByPagination;
using JewelrySalesSystem.Application.Users.GetManagerByPagination;
using JewelrySalesSystem.Application.Users.GetStaffByPagination;
using JewelrySalesSystem.Application.Users.Login;
using JewelrySalesSystem.Application.Users.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using JewelrySalesSystem.Application.Users.StaffRevenue;
using JewelrySalesSystem.Application.Users.ChangePassword;
using JewelrySalesSystem.Application.Users.AssignStaff;
using JewelrySalesSystem.Application.Users.CreateAccount;
using JewelrySalesSystem.Application.Users.VerifyAccount;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;
        public UserController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UserLoginDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserLoginDto>>> Login(
                       [FromBody] LoginQuery query,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            var token = _jwtService.CreateToken(result.ID, result.Role);
            result.Token = token;
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNewUser(
            [FromBody] RegisterCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("user/pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetPagination([FromQuery] GetUserByPaginationQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/filter-user")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetByFilter([FromQuery] FilterUserQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/staff-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetStaffPagination([FromQuery] GetStaffByPaginationQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/customer-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetCustomerPagination([FromQuery] GetCustomerByPaginationQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/manager-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetManagerPagination([FromQuery] GetManagerByPaginationQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user-current")]
        [ProducesResponseType(typeof(JsonResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserDto>>> GetCurrentUser(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetCurrentUserQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPatch("user/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateRole([FromForm] UpdateUserCommand command
            , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("staff/filter-revenue")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<StaffRevenueDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<StaffRevenueDto>>>> StaffFilterRevenue(
            [FromQuery] FilterStaffRevenueQuery query
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [Route("change-password")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> ChangePassword(
                       [FromBody] ChangePasswordUserCommand command,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if(!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string> (result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("manager/assign-staff")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> AssignStaff(
                       [FromBody] AssignStaffCommand command,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Contains("thành công"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPost("admin/create-account")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateAccount(
            [FromBody] CreateAccountCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if (result.Equals("Tài khoản không đủ quyền hạn"))
            {
                return Unauthorized(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }

        [AllowAnonymous]
        [HttpPost("user/verify-email")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> VerifyEmail(
            [FromBody] VerifyEmailCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            if(result.Equals("Token không hợp lệ hoặc đã hết hạn"))
            {
                return BadRequest(new JsonResponse<string>(result));
            }
            return Ok(new JsonResponse<string>(result));
        }
    }
}
