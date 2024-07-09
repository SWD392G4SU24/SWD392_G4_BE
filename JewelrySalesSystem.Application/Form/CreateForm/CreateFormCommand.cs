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

namespace JewelrySalesSystem.Application.Form.CreateForm
{
    public class CreateFormCommand : IRequest<string>, ICommand
    {
        public CreateFormCommand(string content, DateTime appointmentDate, string typeString, string orderId)
        {
            Content = content;
            AppointmentDate = appointmentDate;
            Type = ParseFormType(typeString);
            OrderId = orderId;
            TypeString = typeString; // Set TypeString after parsing to FormType
        }

        public string OrderId { get; set; }

        [JsonIgnore]
        public FormType Type { get; set; }

        public string TypeString { get; set; }

        public string Content { get; set; }
        public DateTime AppointmentDate { get; set; }

        private FormType ParseFormType(string type)
        {
            if (Enum.TryParse(type, true, out FormType result))
            {
                return result;
            }
            throw new NotFoundException("Invalid form type");
        }
    }
}
