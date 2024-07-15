using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.UpdateStatus
{
    public class UpdateStatusFromCommand : IRequest<string>, ICommand
    {
        public UpdateStatusFromCommand(string formID, FormStatus status)
        {
            FormID = formID;
            Status = status;
        }

        public string FormID { get; set; }
        public FormStatus Status { get; set; }
    }
}
