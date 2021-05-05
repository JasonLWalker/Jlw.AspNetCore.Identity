using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(TestMvcWebApp.Areas.Identity.IdentityHostingStartup))]
namespace TestMvcWebApp.Areas.Identity
{
    /*
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                / *

                        services.AddDbContext<TestMvcWebAppContext>(options =>
                            options.UseSqlite(
                                context.Configuration.GetConnectionString("TestMvcWebAppContextConnection")));

                            .AddEntityFrameworkStores<TestMvcWebAppContext>();
                    * /
                services.AddDefaultIdentity<Jlw.Extensions.Identity.Stores.ModularBaseUser<long>>(options => options.SignIn.RequireConfirmedAccount = true);
            });
        }
    }
    */
}