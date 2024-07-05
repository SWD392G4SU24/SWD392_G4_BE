using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace JewelrySalesSystem.Application.GoogleLogin.SignInGoogle
{
    public class SignInGoogleCommand : IRequest<AuthenticationProperties>
    {
        public HttpContext HttpContext { get; }
        public string ReturnUrl { get; }

        public SignInGoogleCommand(HttpContext httpContext, string returnUrl)
        {
            HttpContext = httpContext;
            ReturnUrl = returnUrl;
        }
    }
}
