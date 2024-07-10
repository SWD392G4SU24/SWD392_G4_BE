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
      => mapper.Map<FormDto>(projectFrom);
        public static List<FormDto> MapToFormDtoList(this IEnumerable<FormEntity> projectFrom, IMapper mapper)
         => projectFrom.Select(x => x.MapToFormDto(mapper)).ToList();
    }
}
