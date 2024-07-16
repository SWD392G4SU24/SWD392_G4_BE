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
        public UpdateFormCommand(string formID, string? content, DateTime? appointmentDate)
        {
            FormID = formID;
            Content = content;
            AppointmentDate = appointmentDate;
        }

        public string FormID { get; set; }
        public string? Content { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
