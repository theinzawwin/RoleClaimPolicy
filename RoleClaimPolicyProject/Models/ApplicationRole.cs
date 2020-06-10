using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleClaimPolicyProject.Models
{
    public class ApplicationRole: IdentityRole
    {
        public string Description { get; set; }
        public long DepartmentId { get; set; }
        public ApplicationRole(string Name)
        {
            base.Name = Name;
        }
    }
}
