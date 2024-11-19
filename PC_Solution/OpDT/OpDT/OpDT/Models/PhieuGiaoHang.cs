using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class PhieuGiaoHang
    {
        public DateTime Ngaygh { get; set; }
        public string Diachigh { get; set; } = null!;
        public string? Tennguoinhan { get; set; }
        public string? Mapdh { get; set; }
        public string? Manv { get; set; }

        public virtual AccountManagement? ManvNavigation { get; set; }
        public virtual PhieuDatHang? MapdhNavigation { get; set; }
    }
}
