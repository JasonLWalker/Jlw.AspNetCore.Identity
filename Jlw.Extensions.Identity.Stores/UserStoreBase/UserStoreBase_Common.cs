using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jlw.Extensions.Identity.Stores
{

    public partial class UserStoreBase<TUser, TKey, TUserClaim, TUserLogin>
    {
        protected virtual ICollection<Microsoft.AspNetCore.Identity.IdentityUserToken<TKey>> Tokens { get; private set; } = new List<Microsoft.AspNetCore.Identity.IdentityUserToken<TKey>>();


        /// <inheritdoc />
        public override Task<Microsoft.AspNetCore.Identity.IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<Microsoft.AspNetCore.Identity.IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<Microsoft.AspNetCore.Identity.IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override Task<TUser> FindUserAsync(TKey userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override Task<TUserLogin> FindUserLoginAsync(TKey userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override Task<TUserLogin> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc />
        protected override Task<Microsoft.AspNetCore.Identity.IdentityUserToken<TKey>> FindTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            return Task.FromResult(Tokens.FirstOrDefault(o => o.UserId.ToString() == user.Id.ToString() && o.LoginProvider == loginProvider && o.Name == name));
        }

        /// <inheritdoc />
        protected override Task AddUserTokenAsync(Microsoft.AspNetCore.Identity.IdentityUserToken<TKey> token)
        {
            Tokens.Add(token);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        protected override Task RemoveUserTokenAsync(Microsoft.AspNetCore.Identity.IdentityUserToken<TKey> token)
        {
            //throw new NotImplementedException();
            var t = Tokens.FirstOrDefault(o => o.UserId.ToString() == token.UserId.ToString() && o.LoginProvider == token.LoginProvider && o.Name == token.Name);
            if (t != null)
            {
                Tokens.Remove(t);
            }

            return Task.CompletedTask;
        }
    }
}
