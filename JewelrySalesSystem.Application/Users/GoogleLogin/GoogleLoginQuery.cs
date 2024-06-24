using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;

namespace JewelrySalesSystem.Application.Users.GoogleLogin
{
    public class GoogleLoginQuery : IRequest<UserLoginDto>, IQuery
    {
        public string Email { get; set; }
        public string FullName { get; set; }

        public GoogleLoginQuery(string email, string fullName)
        {
            Email = email;
            FullName = fullName;
        }
    }
}
