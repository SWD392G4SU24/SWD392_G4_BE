using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Users.GoogleLogin;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jewelry_Sales_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleLoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;

        public GoogleLoginController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpGet("signin-google")]
        public IActionResult SignInGoogle(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("SigninGoogleCallback", "GoogleLogin", new { returnUrl })
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("signin-google-callback")]
        public async Task<IActionResult> SigninGoogleCallback(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded)
                return BadRequest();

            var claims = authenticateResult.Principal.Identities.First().Claims;
            var emailClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (emailClaim != null && nameClaim != null)
            {
                var query = new GoogleLoginQuery(emailClaim.Value, nameClaim.Value);
                var result = await _mediator.Send(query);

                var token = _jwtService.CreateToken(result.ID, result.Role);
                return Redirect(returnUrl + "?token=" + token);
            }

            return Redirect("/login-failed");
        }

    }
}
