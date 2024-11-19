using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class AccountManagement
    {
        public AccountManagement()
        {
            PhieuGiaoHangs = new HashSet<PhieuGiaoHang>();
        }

        public string AccountUsername { get; set; } = null!;
        public string AccountPassword { get; set; } = null!;
        public string? GroupId { get; set; }

        public virtual GroupManagement? Group { get; set; }
        public virtual ICollection<PhieuGiaoHang> PhieuGiaoHangs { get; set; }
    }
}
