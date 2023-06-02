using Jlw.Extensions.Identity.Stores;
using Jlw.Utilities.Data.DbUtility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Jlw.Extensions.Identity.Mock;
using Jlw.Extensions.ModularDbClient;
using UserLong = Jlw.Extensions.Identity.Stores.ModularBaseUser<long>;

namespace TestMvcWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<UserLong>, PlainTextPasswordHasher<UserLong>>();

            var dbClient = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            //services.AddSingleton<IModularDbClient>(dbClient);
            services.AddModularDbClient(Configuration.GetConnectionString("DefaultConnection"), dbClient);

            services.AddTransient<IUserStore<UserLong>>(provider =>
            {
                var repo = provider.GetRequiredService(typeof(IModularDbClient)) as IModularDbClient;
                return new ModularDbClientUserStore<UserLong, long>(Configuration.GetConnectionString("DefaultConnection"), repo);
            });
            services.AddTransient<IRoleStore<IModularBaseRole<long>>, ModularRoleStoreBase<long>>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });


            services.AddDefaultIdentity<UserLong>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            // using Microsoft.AspNetCore.Identity.UI.Services;
            //services.AddSingleton<IEmailSender, EmailSender>();


            services.AddControllersWithViews();
            services.AddRazorPages(options =>
            {

            });
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
