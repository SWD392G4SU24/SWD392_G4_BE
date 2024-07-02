using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoogleLogin.SignInCallback
{
    public class SignInGoogleCallbackQueryHandler : IRequestHandler<SignInGoogleCallbackQuery, SignInGoogleCallbackResponse>
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SignInGoogleCallbackQueryHandler(IJwtService jwtService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInGoogleCallbackResponse> Handle(SignInGoogleCallbackQuery request, CancellationToken cancellationToken)
        {
            var authenticateResult = await request.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded)
                throw new Exception("Authentication failed.");

            var claims = authenticateResult.Principal.Identities.First().Claims;
            var emailClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (emailClaim != null && nameClaim != null)
{
                var user = await _userRepository.FindByEmailAsync(emailClaim.Value);
                if (user == null)
    {
                    throw new Exception("User not found.");
                }

                var token = _jwtService.CreateToken(user.ID, user.Role.Name);
                return new SignInGoogleCallbackResponse(user.Email, user.FullName, token);
            }

            throw new Exception("Invalid claims.");
        }
    }
}
