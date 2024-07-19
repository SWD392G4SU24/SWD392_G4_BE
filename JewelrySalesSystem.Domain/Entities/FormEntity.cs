using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Domain.Entities
{
    public class FormEntity : BaseEntity
    {
        public required FormType Type { get; set; }
        public string? Content {  get; set; }
        public required FormStatus Status { get; set; }
        public required DateTime AppoinmentDate {  get; set; }

        public virtual UserEntity? Creator { get; set; }
    }
}
