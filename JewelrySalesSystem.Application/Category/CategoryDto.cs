using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category
{
    public class CategoryDto : IMapFrom<CategoryDto>
    {
        public CategoryDto() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryEntity, CategoryDto>();
        }
    }
}
