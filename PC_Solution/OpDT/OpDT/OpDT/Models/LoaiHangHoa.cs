using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class LoaiHangHoa
    {
        public LoaiHangHoa()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        public string Maloai { get; set; } = null!;
        public string? Mansx { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
