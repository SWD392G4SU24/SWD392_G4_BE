using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities
{
    public class KhuyenMaiEntity : BaseEntity
    {
        public required decimal DieuKienSuDung {  get; set; }
        public required float PhanTramGiam {  get; set; }
        public required decimal GiamToiDa {  get; set; }
        public required int DiemDoiThuong {  get; set; }
        public virtual ICollection<PhanLoaiEntity> PhanLoais { get; set;}
        public virtual ICollection<UsersEntity> Users { get; set;}
    }
}
