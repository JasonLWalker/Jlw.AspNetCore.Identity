using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jlw.Extensions.Identity.Stores;

namespace Jlw.Extensions.Identity.Mock
{
    public class MockUserStore<TUser> : MockUserStore<TUser, string> where TUser : ModularBaseUser, new()
    {

    }


    public class MockUserStore<TUser, TKey> : ModularUserStoreBase<TUser, TKey> 
        where TUser : ModularBaseUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        protected static List<TUser> MockedUsers = new List<TUser>();

        public static IUserStore<TUser> UserStoreFactory(IServiceProvider arg)
        {
            return new MockUserStore<TUser, TKey>();
        }
        
        public override Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(MockedUsers.FirstOrDefault(o=>o.NormalizedUserName.Equals(normalizedUserName, StringComparison.InvariantCultureIgnoreCase)));
        }

        public override Task<TUser> FindByIdAsync(string id, CancellationToken cancellationToken)
        {
            return Task.FromResult(MockedUsers.FirstOrDefault(o =>  o?.Id?.ToString()?.Equals(id, StringComparison.InvariantCultureIgnoreCase) ?? default));
        }

        public static void AddMockedUser(TUser user, IEnumerable<IdentityUserClaim<TKey>> claims = null)
        {
            TUser u = (TUser)user.CopyFrom(user);
            if (claims != null)
            {
                foreach (var claim in claims)
                {
                    u.Claims.Add(claim);
                }
            }

            MockedUsers.Add(u);
        }
    }
}
