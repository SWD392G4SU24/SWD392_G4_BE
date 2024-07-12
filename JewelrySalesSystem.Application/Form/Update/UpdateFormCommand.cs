using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.Update
{
    public class UpdateFormCommand : IRequest<string>, ICommand
    {
        public UpdateFormCommand(string id, string content, DateTime appointmentDate)
        {
            Id = id;
            Content = content;
            AppointmentDate = appointmentDate;
        }

        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
