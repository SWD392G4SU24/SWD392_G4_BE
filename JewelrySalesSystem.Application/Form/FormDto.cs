using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form
{
    public class FormDto : IMapFrom<FormEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FormEntity, FormDto>();
        }
        public string ID { get; set; }
        public string Type { get; set; }
        public string Status {  get; set; }
        public string? Content { get; set; }
        public string CreatorID {  get; set; }
        public string FullName {  get; set; }
        public DateTime AppoinmentDate { get; set; }
        public FormDto()
        {
            
        }
    }
}
