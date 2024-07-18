using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.ChangePassword
{
    public class ChangePasswordUserCommand : IRequest<string>, ICommand
    {
        public ChangePasswordUserCommand()
        {
            
        }
        public ChangePasswordUserCommand(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
        public string OldPassword {  get; set; }
        public string NewPassword { get; set; }
    }
}
