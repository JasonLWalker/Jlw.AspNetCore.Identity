using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    public partial class ModularUserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : IUserPasswordStore<TUser>
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
