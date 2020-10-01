using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    public class ModularUserStoreBase :
        ModularUserStoreBase<ModularBaseUser>
    {
    }

    public class ModularUserStoreBase<TUser> : 
        ModularUserStoreBase<TUser, string> 
        where TUser : ModularBaseUser, new()
    {
    }

    public class ModularUserStoreBase<TUser, TKey> :
        ModularUserStoreBase<TUser, TKey, IdentityUserClaim<TKey>>
        where TUser : ModularBaseUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {

    }

    public class ModularUserStoreBase<TUser, TKey, TUserClaim> :
        ModularUserStoreBase<TUser, TKey, TUserClaim, IdentityUserLogin<TKey>>
        where TUser : ModularBaseUser<TKey>, new()
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>, new()
    {

    }

    public partial class ModularUserStoreBase<TUser, TKey, TUserClaim, TUserLogin> :
        Microsoft.AspNetCore.Identity.UserStoreBase<TUser, TKey, TUserClaim, TUserLogin, IdentityUserToken<TKey>>
        where TUser : ModularBaseUser<TKey>, new()
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>, new()
        where TUserLogin : IdentityUserLogin<TKey>, new()
    {
        public ModularUserStoreBase(IdentityErrorDescriber describer = null) : base(describer ?? new IdentityErrorDescriber())
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
