using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jlw.Extensions.Identity.Stores;

namespace Jlw.Extensions.Identity.Mock
{
    public class MockUserStore<TUser> : ModularUserStoreBase<TUser> where TUser : ModularBaseUser, new()
    {
        protected static List<TUser> MockedUsers = new List<TUser>();

        public static IUserStore<TUser> UserStoreFactory(IServiceProvider arg)
        {
            return new MockUserStore<TUser>();
        }
        
        public override Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(MockedUsers.FirstOrDefault(o=>o.NormalizedUserName.Equals(normalizedUserName, StringComparison.InvariantCultureIgnoreCase)));
        }

        public override Task<TUser> FindByIdAsync(string id, CancellationToken cancellationToken)
        {
            return Task.FromResult(MockedUsers.FirstOrDefault(o => o.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase)));
        }

        public static void AddMockedUser(TUser user, IEnumerable<IdentityUserClaim<string>> claims = null)
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
