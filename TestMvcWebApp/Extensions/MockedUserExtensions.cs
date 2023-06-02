using Jlw.Extensions.Identity.Mock;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TestMvcWebApp
{
    public static class MockedUserExtensions
    {

        public static IServiceCollection AddMockedUsers<TUser>(this IServiceCollection services) where TUser : Jlw.Extensions.Identity.Stores.ModularBaseUser, new()
        {
            int id = 1;
            string temp;



            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = "jasonlwalker",
                    NormalizedUserName = "jasonlwalker",
                    Email = "jason@draxjinn.info",
                    NormalizedEmail = "jason@draxjinn.info",
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                { }
                );

            
            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = "testuser@sps.org",
                    NormalizedUserName = "testuser@sps.org",
                    Email = "testuser@sps.org",
                    NormalizedEmail = "testuser@sps.org",
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                    { }
            );

            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = "r12mail\\rlash",
                    NormalizedUserName = "r12mail\\rlash",
                    Email = "rlash@sps.org",
                    NormalizedEmail = "rlash@sps.org",
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                    { }
            );

            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = "testsuper@sps.org",
                    NormalizedUserName = "testsuper@sps.org",
                    Email = "testsuper@sps.org",
                    NormalizedEmail = "testsuper@sps.org",
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                    { }
            );


            temp = "testuser@test.org";
            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = temp,
                    NormalizedUserName = temp.ToUpper(),
                    Email = temp,
                    NormalizedEmail = temp.ToUpper(),
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[] { }
            );

            temp = "jasonlwalker";
            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = temp,
                    NormalizedUserName = temp.ToUpper(),
                    Email = temp,
                    NormalizedEmail = temp.ToUpper(),
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[] { }
            );

            temp = "teststaff@test.org";
            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = temp,
                    NormalizedUserName = temp.ToUpper(),
                    Email = temp,
                    NormalizedEmail = temp.ToUpper(),
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                    { }
            );

            temp = "testadmin@test.org";
            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = temp,
                    NormalizedUserName = temp.ToUpper(),
                    Email = temp,
                    NormalizedEmail = temp.ToUpper(),
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                    { }
            );

            temp = "testsuper@test.org";
            MockUserStore<TUser>.AddMockedUser(
                GetNewUser<TUser>(new
                {
                    Id = id++,
                    UserName = temp,
                    NormalizedUserName = temp.ToUpper(),
                    Email = temp,
                    NormalizedEmail = temp.ToUpper(),
                    PasswordHash = "test",
                    EmailConfirmed = true
                }),
                new IdentityUserClaim<string>[]
                    { }
            );

            return services;
        }

        public static T GetNewUser<T>(object o)
        {
            var constructor = typeof(T).GetConstructor(new[] { typeof(object) });
            if (constructor is null)
                return default;

            return (T)constructor.Invoke(new[] { o });
        }

    }
}
