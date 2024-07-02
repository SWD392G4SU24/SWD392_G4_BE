using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users
{
    public class UserDto : IMapFrom<UserEntity>
    {
        public string ID {  get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber {  get; set; }
        public string Address { get; set; }
        public int Point {  get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserEntity, UserDto>();
        }
    }
}
