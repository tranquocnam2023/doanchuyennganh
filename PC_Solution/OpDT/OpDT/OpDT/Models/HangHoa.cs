using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class HangHoa
    {
        public string Mahang { get; set; } = null!;
        public string Tenhang { get; set; } = null!;
        public string? Donvitinh { get; set; }
        public double? Dongia { get; set; }
        public string? Hinh { get; set; }
        public string? Maloai { get; set; }

        public virtual LoaiHangHoa? MaloaiNavigation { get; set; }
    }
}
