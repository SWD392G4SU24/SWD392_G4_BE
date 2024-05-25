using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("SanPham")]
    public class SanPhamEntity : BaseEntity
    {
        public required decimal GiaSanPham {  get; set; }
        public required float TrongLuong {  get; set; }
        public required int SoLuong { get; set; }
        public string? MoTa {  get; set; }
        public required int PhanLoaiID {  get; set; }
        [ForeignKey(nameof(PhanLoaiID))]
        public virtual PhanLoaiEntity PhanLoai {  get; set; }
    }
}
