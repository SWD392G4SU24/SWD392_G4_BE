using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.AssignStaff
{
    public class AssignStaffCommand : IRequest<string>, ICommand
    {
        public AssignStaffCommand()
        {
            
        }
        public string StaffID { get; set; }
        public int CounterID {  get; set; }
    }
}
