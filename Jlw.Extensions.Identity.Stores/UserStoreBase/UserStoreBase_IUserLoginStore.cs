using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Jlw.Extensions.Identity.Stores
{

    public partial class UserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>
    {
        private readonly Dictionary<string, TUser> _users = new Dictionary<string, TUser>();

        public override IQueryable<TUser> Users => _users.Values.AsQueryable();

        public override Task AddLoginAsync(TUser user, Microsoft.AspNetCore.Identity.UserLoginInfo login, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<IList<Microsoft.AspNetCore.Identity.UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }

}
