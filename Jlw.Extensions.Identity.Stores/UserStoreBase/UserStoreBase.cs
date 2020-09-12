using System;
using System.Threading;

namespace Jlw.Extensions.Identity.Stores
{
    public class UserStoreBase :
        UserStoreBase<IdentityUser>
    {
    }

    public class UserStoreBase<TUser> : 
        UserStoreBase<TUser, string> 
        where TUser : IdentityUser, new()
    {
    }

    public class UserStoreBase<TUser, TKey> :
        UserStoreBase<TUser, TKey, Microsoft.AspNetCore.Identity.IdentityUserClaim<TKey>>
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {

    }

    public class UserStoreBase<TUser, TKey, TUserClaim> :
        UserStoreBase<TUser, TKey, TUserClaim, Microsoft.AspNetCore.Identity.IdentityUserLogin<TKey>>
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
        where TUserClaim : Microsoft.AspNetCore.Identity.IdentityUserClaim<TKey>, new()
    {

    }

    public partial class UserStoreBase<TUser, TKey, TUserClaim, TUserLogin> :
        Microsoft.AspNetCore.Identity.UserStoreBase<TUser, TKey, TUserClaim, TUserLogin, Microsoft.AspNetCore.Identity.IdentityUserToken<TKey>>
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
        where TUserClaim : Microsoft.AspNetCore.Identity.IdentityUserClaim<TKey>, new()
        where TUserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<TKey>, new()
    {
        public UserStoreBase(Microsoft.AspNetCore.Identity.IdentityErrorDescriber describer = null) : base(describer ?? new Microsoft.AspNetCore.Identity.IdentityErrorDescriber())
        {

        }

        private bool _disposed;

        /// <inheritdoc />
        public new virtual void Dispose()
        {
            base.Dispose();
            _disposed = true;
        }
        
        
        protected void ThrowIfNullDisposedCancelled(TUser user, CancellationToken token)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            token.ThrowIfCancellationRequested();
        }
        
        protected void ThrowIfDisposedOrCancelled(CancellationToken token)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
            token.ThrowIfCancellationRequested();
        }
    }
}
