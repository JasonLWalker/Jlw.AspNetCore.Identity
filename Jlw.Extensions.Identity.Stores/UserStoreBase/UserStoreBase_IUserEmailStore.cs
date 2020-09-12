using System;
using System.Threading;
using System.Threading.Tasks;


namespace Jlw.Extensions.Identity.Stores
{
    public partial class UserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : Microsoft.AspNetCore.Identity.IUserEmailStore<TUser>
    {
        /// <inheritdoc />
        public override Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
