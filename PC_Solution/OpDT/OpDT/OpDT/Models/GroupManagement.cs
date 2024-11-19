using System;
using System.Collections.Generic;

namespace OpDT.Models
{
    public partial class GroupManagement
    {
        public GroupManagement()
        {
            AccountManagements = new HashSet<AccountManagement>();
            GroupFunctions = new HashSet<GroupFunction>();
        }

        public string GroupId { get; set; } = null!;
        public string GroupName { get; set; } = null!;

        public virtual ICollection<AccountManagement> AccountManagements { get; set; }
        public virtual ICollection<GroupFunction> GroupFunctions { get; set; }
    }
}
