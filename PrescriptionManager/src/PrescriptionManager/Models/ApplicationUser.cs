using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PrescriptionManager.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public List<Medication> AllMeds { get; set; } = new List<Medication>();
        public PermissionLevel PermissionLevel { get; set; } = PermissionLevel.User;

    }
}
