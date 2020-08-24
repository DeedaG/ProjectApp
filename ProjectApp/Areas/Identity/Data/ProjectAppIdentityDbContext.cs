using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Areas.Identity.Data
{
    public class ProjectAppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public ProjectAppIdentityDbContext(DbContextOptions<ProjectAppIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(p => p.Projects)
                .WithOne(u => u.User)
                .IsRequired();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
