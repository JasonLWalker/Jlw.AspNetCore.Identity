using System;
using System.Threading;
using System.Threading.Tasks;


namespace Jlw.Extensions.Identity.Stores
{
    public partial class UserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>
    {

        /// <inheritdoc />
        public override Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
        {
            ThrowIfNullDisposedCancelled(user, cancellationToken);

            if (user == null)
                throw new ArgumentNullException(nameof(user), "Value cannot be null.");

            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }
    }
}
