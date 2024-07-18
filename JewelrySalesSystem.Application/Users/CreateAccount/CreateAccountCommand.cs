using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.CreateAccount
{
    public class CreateAccountCommand : IRequest<string>, ICommand
    {
        public CreateAccountCommand(string username, string fullName, string email, string phoneNumber, string address, int roleID)
        {
            Username = username;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            RoleID = roleID;
        }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int RoleID { get; set; }
    }
}
