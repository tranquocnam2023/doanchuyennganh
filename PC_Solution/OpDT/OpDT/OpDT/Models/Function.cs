using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class Function
    {
        public Function()
        {
            GroupFunctions = new HashSet<GroupFunction>();
        }

        public string FunctionId { get; set; } = null!;
        public string FunctionName { get; set; } = null!;

        public virtual ICollection<GroupFunction> GroupFunctions { get; set; }
    }
}
