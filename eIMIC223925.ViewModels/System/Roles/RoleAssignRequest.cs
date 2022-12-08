using eIMIC223925.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eIMIC223925.ViewModels.System.Roles
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
