using JewelrySalesSystem.Application.GoogleLogin.SignInGoogle;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoogleLogin.SignInGoogle
{
    public class SignInGoogleCommandHandler : IRequestHandler<SignInGoogleCommand, AuthenticationProperties>
    {
        public Task<AuthenticationProperties> Handle(SignInGoogleCommand request, CancellationToken cancellationToken)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = request.HttpContext.Request.Scheme + "://" + request.HttpContext.Request.Host + "/api/GoogleLogin/signin-google-callback?returnUrl=" + request.ReturnUrl
            };
            return Task.FromResult(properties);
        }
    }
}
