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
    public class UsersLoginDto : IMapFrom<UsersEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsersEntity, UsersLoginDto>();
        }
        public string Username { get; set; }
        public string ID { get; set; }
        public string Role { get; set; }
        public static UsersLoginDto Create(string username, string id, string role)
        {
            return new UsersLoginDto
            {
                Username = username,
                ID = id,
                Role = role
            };
        }
    }
}
