using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JewelrySalesSystem.Application.GoogleLogin.SignInGoogle;
using JewelrySalesSystem.Application.GoogleLogin.SignInCallback;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleLoginController : ControllerBase
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
        public async Task<IActionResult> SignInGoogleCallback([FromQuery] string returnUrl = "/")
        {
            var query = new SignInGoogleCallbackQuery(HttpContext);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
