using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectApp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(ProjectApp.Areas.Identity.IdentityHostingStartup))]
namespace ProjectApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjectAppIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("ProjectAppIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ProjectAppIdentityDbContext>();
            });
        }
    }
}