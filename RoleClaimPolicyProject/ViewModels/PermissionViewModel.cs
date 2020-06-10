using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleClaimPolicyProject.ViewModels
{
    public class PermissionViewModel
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public  Boolean IsSelected { get; set; }
    }
}
