using JewelrySalesSystem.Application.GoogleLogin.SignInGoogle;
using JewelrySalesSystem.Application.GoogleLogin.SignInCallback;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Google;
using JewelrySalesSystem.Application.GoogleLogin.SignInGoogle;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    public class GoogleLoginController : Controller
    {
        private readonly IMediator _mediator;

        public GoogleLoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("signin-google")]
        public async Task<IActionResult> SignInGoogle([FromQuery] string returnUrl = "/")
        {
            var command = new SignInGoogleCommand(HttpContext, returnUrl);
            var properties = await _mediator.Send(command);
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("signin-google-callback")]
        public async Task<IActionResult> SigninGoogleCallback(string returnUrl = "/")
        {
            var query = new SignInGoogleCallbackQuery(HttpContext);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
