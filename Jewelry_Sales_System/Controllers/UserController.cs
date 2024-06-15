using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using JewelrySalesSystem.Application.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Jewelry_Sales_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("user/login")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Login(
                       [FromBody] LoginQuery query,
                                  CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            var token = _jwtService.CreateToken(result.ID, result.Role);
            return Ok(new JsonResponse<string>(token));
        }

        [HttpPost]
        [Route("user/register")]
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

        [AllowAnonymous]
        [HttpGet("signin-google")]
        public IActionResult SignInGoogle(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("SigninGoogleCallback", new { returnUrl }) };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("signin-google-callback")]
        public async Task<IActionResult> SigninGoogleCallback(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded)
                return BadRequest();

            // Xử lý thông tin người dùng từ authenticateResult.Principal và tạo JWT nếu cần thiết.
            var claims = authenticateResult.Principal.Identities.First().Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier);
            var emailClaim = claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (idClaim != null && emailClaim != null)
            {
                var userId = idClaim.Value;
                var email = emailClaim.Value;
                // Tạo JWT hoặc xử lý logic đăng nhập tại đây.
                var token = _jwtService.CreateToken(userId, "UserRole"); // Chỉnh sửa "UserRole" theo vai trò của bạn
                return Redirect(returnUrl + "?token=" + token);
            }

            return Redirect("/login-failed"); // Chuyển hướng đến trang đăng nhập thất bại nếu cần
        }
    }
}
