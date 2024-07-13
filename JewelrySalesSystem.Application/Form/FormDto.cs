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
            profile.CreateMap<FormEntity, FormDto>()
                .ForMember(dest => dest.TypeString, opt => opt.MapFrom(src => src.Type.ToString()));
        }
        public required string Id { get; set; }
        public string TypeString { get; set; }
        public string? Content { get; set; }
        public required DateTime AppoinmentDate { get; set; }
    }
}
