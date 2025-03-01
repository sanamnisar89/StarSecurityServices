using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;
using System.Collections.Generic;
using System.Reflection;

namespace StarSecurityServices.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<IdentityUser>(options) // Inherit from IdentityDbContext to integrate IdentityUser
    {
        // DbSets for your models
        public required DbSet<Contact> Contacts { get; set; }
        public DbSet<StarSecurityServices.Models.Network> Network { get; set; } = default!;
    }
}
