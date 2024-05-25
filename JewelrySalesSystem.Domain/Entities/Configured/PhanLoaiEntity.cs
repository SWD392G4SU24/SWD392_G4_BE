using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities.Configured
{
    public class PhanLoaiEntity : ConfiguredEntity
    {
        public virtual ICollection<KhuyenMaiEntity> KhuyenMais { get; set; }
        public virtual ICollection<SanPhamEntity> SanPhams { get; set;}
    }
}
