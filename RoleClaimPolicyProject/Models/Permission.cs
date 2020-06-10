using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoleClaimPolicyProject.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
