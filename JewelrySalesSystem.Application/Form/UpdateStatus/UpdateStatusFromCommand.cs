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
        public UpdateStatusFromCommand(string id, string statusString)
        {
            Id = id;
            Status = ParseFormStatus(statusString);
            StatusString = statusString;
        }

        public string Id { get; set; }
        [JsonIgnore]
        public FormStatus Status { get; set; }

        public string StatusString { get; set; }

        private FormStatus ParseFormStatus(string status)
        {
            if (Enum.TryParse(status, true, out FormStatus result))
            {
                return result;
            }
            throw new NotFoundException("Invalid FormStatus");
        }
    }
}
