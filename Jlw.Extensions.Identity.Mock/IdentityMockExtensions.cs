﻿using System;
using Jlw.Extensions.Identity.Stores;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Jlw.Extensions.Identity.Mock;

// ReSharper disable once CheckNamespace
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
                option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                option.SlidingExpiration = true;
            });


            return services;
        }
        public static IServiceCollection AddIdentityMocking<TUser, TKey>(this IServiceCollection services)
            where TKey : IEquatable<TKey> 
            where TUser : ModularBaseUser<TKey>, IModularBaseUser<TKey>, new()
            
        {
            services.AddTransient<IUserStore<TUser>>(MockUserStore<TUser, TKey>.UserStoreFactory);
            services.AddTransient<IRoleStore<IModularBaseRole<TKey>>, ModularRoleStoreBase<TKey>>();
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