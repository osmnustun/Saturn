using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DTO
{
    public class UserRoleDTO
    {
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
