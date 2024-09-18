using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Identity.Models
{
    public class Role:IdentityRole
    {
        public Role() { }
        public Role(string roleName, string description)
        {
            Name = roleName;
            Description = description;
        }
        public string? Description { get; set; }=string.Empty;
    }
}
