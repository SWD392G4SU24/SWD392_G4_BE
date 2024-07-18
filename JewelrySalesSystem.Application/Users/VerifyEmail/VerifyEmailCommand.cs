using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.VerifyAccount
{
    public class VerifyEmailCommand : IRequest<string>, ICommand
    {
        public VerifyEmailCommand(string userID, string token)
        {
            UserID = userID;
            Token = token;
        }
        public string UserID {  get; set; }
        public string Token { get; set; }
    }
}
