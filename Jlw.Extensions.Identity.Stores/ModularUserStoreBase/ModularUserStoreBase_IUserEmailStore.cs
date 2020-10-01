using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    public partial class ModularUserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : IUserEmailStore<TUser>
    {
        /// <inheritdoc />
        public override Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
