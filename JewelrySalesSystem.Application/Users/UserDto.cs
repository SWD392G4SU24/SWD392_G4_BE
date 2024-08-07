﻿using AutoMapper;
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
        public int RoleID {  get; set; }
        public string Role { get; set; }
        public int? CounterID { get; set; }
        public string? Counter {  get; set; }
        public int Point {  get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserEntity, UserDto>();
        }
        public UserDto()
        {
            
        }
        public UserDto(string id, string fullName, string email, string phoneNumber, string address, int roleID, string role, int point)
        {
            ID = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            RoleID = roleID;
            Role = role;
            Point = point;
        }
    }
}
