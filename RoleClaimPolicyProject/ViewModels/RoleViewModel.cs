using RoleClaimPolicyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleClaimPolicyProject.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PermissionViewModel> Permissions { get; set; }
    }
}
