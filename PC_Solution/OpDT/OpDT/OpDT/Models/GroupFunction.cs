using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class GroupFunction
    {
        public string FunctionId { get; set; } = null!;
        public string GroupId { get; set; } = null!;
        public bool? IsEnable { get; set; }

        public virtual Function Function { get; set; } = null!;
        public virtual GroupManagement Group { get; set; } = null!;
    }
}
