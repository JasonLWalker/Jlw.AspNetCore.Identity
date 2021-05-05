using System;
using Jlw.Extensions.Identity.Stores;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Jlw.Extensions.Identity.Mock;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityMockExtensions
    {
        public static IServiceCollection AddIdentityMocking<TUser>(this IServiceCollection services) where TUser : ModularBaseUser, new()
        {
            services.AddTransient<IUserStore<TUser>>(MockUserStore<TUser>.UserStoreFactory);
            services.AddTransient<IRoleStore<IModularBaseRole<long>>, ModularRoleStoreBase<long>>();
            services.AddTransient<IPasswordHasher<TUser>>(sp => new PlainTextPasswordHasher<TUser>());

            services.AddDefaultIdentity<TUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddRazorPages(options => { }); // Adds Identity UI and other Razor pages

            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, option =>
            {
                //option.Cookie.Name = $".{config.SiteId}.Identity.{config.LoginType}"; // change cookie name
                //option.Cookie.Path = (config.WebRootPath ?? "/").TrimEnd('/');
                option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                option.SlidingExpiration = true;
            });


            return services;
        }

        public static IApplicationBuilder UseIdentityMocking(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}