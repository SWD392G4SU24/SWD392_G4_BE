using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("Users")]
    public class UsersEntity : BaseEntity
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string HoVaTen { get; set; }
        public required string Email { get; set; }
        [MaxLength(11)]
        public required string SoDienThoai { get; set; }
        public required string DiaChi {  get; set; }
        public required int DiemThuong { get; set; } = 0;
        public required int RoleID {  get; set; }
        [ForeignKey(nameof(RoleID))]
        public virtual RoleEntity Role {  get; set; }
        public virtual ICollection<KhuyenMaiEntity> KhuyenMais { get; set; }
    }
}
