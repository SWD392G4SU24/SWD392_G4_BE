using AutoMapper;
using JewelrySalesSystem.Application.Order;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form
{
    public static class FormMappingExtension
    {
        public static FormDto MapToFormDto(this FormEntity projectFrom, IMapper mapper)
        {
            var result = mapper.Map<FormDto>(projectFrom);
            result.Status = result.Status.ToString();
            result.Type = result.Type.ToString();
            return result;
        }    
        public static List<FormDto> MapToFormDtoList(this IEnumerable<FormEntity> projectFrom, IMapper mapper)
         => projectFrom.Select(x => x.MapToFormDto(mapper)).ToList();

        public static FormDto MapToFormDto(this FormEntity projectFrom, IMapper mapper, string fullname)
        {
            var result = mapper.Map<FormDto>(projectFrom);
            result.FullName = fullname;
            return result;
        }
        public static List<FormDto> MapToFormDtoList(this IEnumerable<FormEntity> projectFrom, IMapper mapper, Dictionary<string, string> fullname)
         => projectFrom.Select(x => x.MapToFormDto(mapper,
             !string.IsNullOrEmpty(x.CreatorID) && fullname.ContainsKey(x.CreatorID) ? fullname[x.CreatorID] : "Lỗi"
             )).ToList();

    }
}
