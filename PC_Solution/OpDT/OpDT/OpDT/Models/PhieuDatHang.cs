using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class PhieuDatHang
    {
        public PhieuDatHang()
        {
            PhieuGiaoHangs = new HashSet<PhieuGiaoHang>();
        }

        public string Mapdh { get; set; } = null!;
        public DateTime? Ngaydh { get; set; }
        public DateTime? Ngaygh { get; set; }
        public string Diachigh { get; set; } = null!;
        public string? Makh { get; set; }

        public virtual ICollection<PhieuGiaoHang> PhieuGiaoHangs { get; set; }
    }
}
