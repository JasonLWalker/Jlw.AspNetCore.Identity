using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{

    public partial class ModularUserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : IUserLoginStore<TUser>
    {
        private readonly Dictionary<string, TUser> _users = new Dictionary<string, TUser>();

        public override IQueryable<TUser> Users => _users.Values.AsQueryable();

        public override Task AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }

}
