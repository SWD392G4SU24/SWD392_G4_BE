﻿using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {   
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required UserStatus Status { get; set; }
        public required string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Range(1, 50, ErrorMessage = "Email Address cannot be over 50 characters!")]
        public required string Email { get; set; }
        [MaxLength(11)]
        public required string PhoneNumber { get; set; }
        public required string Address {  get; set; }
        public required int Point { get; set; } = 0;
        public required int RoleID {  get; set; }
        [ForeignKey(nameof(RoleID))]
        public virtual RoleEntity Role {  get; set; }
        public int? CounterID { get; set; }
        [ForeignKey(nameof(CounterID))]
        public virtual CounterEntity? Counter { get; set; }
        public virtual ICollection<PromotionEntity> Promotions { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
