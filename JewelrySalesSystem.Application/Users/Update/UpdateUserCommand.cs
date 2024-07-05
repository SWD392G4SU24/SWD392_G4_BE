using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Users.Update
{
    public class UpdateUserCommand : IRequest<string>, ICommand
    {
        public UpdateUserCommand()
        {
            
        }
        public UpdateUserCommand(string userID, string? password, UserStatus? status, string? fullName, string? email
            , string? phoneNumber, string? address, int? point, int? roleID, int? counterID)
        {
            UserID = userID;
            Password = password;
            Status = status;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            RoleID = roleID;
            CounterID = counterID;
        }
        public string UserID { get; set; }
        public string? Password { get; set; }
        public UserStatus? Status { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? Point { get; set; } 
        public int? RoleID { get; set; }
        public int? CounterID { get; set; }
    }
}
