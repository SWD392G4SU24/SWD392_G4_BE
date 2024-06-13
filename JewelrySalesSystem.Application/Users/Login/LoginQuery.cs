using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.Login
{
    public class LoginQuery : IRequest<UserLoginDto>, IQuery
    {
        public LoginQuery()
        {

        }
        public LoginQuery(LoginEntity loginEntity)
        {
            user.Email = loginEntity.Email;
            user.Password = loginEntity.Password;
        }
        public required LoginEntity user { get; set; }
    }
}
