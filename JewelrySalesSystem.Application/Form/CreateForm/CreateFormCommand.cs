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
            public CreateFormCommand(string content, FormType type, string orderId)
            {
                Content = content;
                Type = type;
                OrderId = orderId;
            }

            public string OrderId { get; set; }
            public FormType Type { get; set; }
            public string Content { get; set; }
            public CreateFormCommand()
            {
            
            }
        }
}
