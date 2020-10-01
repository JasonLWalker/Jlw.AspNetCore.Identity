using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    public class ModularRoleStoreBase : ModularRoleStoreBase<IModularBaseRole<int>>
    {

    }

    public class ModularRoleStoreBase<TKey> : IRoleStore<IModularBaseRole<TKey>>
    {
        public virtual void Dispose()
        {
            // Nothing to dispose
        }

        public virtual Task<IdentityResult> CreateAsync(IModularBaseRole<TKey> role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityResult> UpdateAsync(IModularBaseRole<TKey> role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityResult> DeleteAsync(IModularBaseRole<TKey> role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetRoleIdAsync(IModularBaseRole<TKey> role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetRoleNameAsync(IModularBaseRole<TKey> role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetRoleNameAsync(IModularBaseRole<TKey> role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetNormalizedRoleNameAsync(IModularBaseRole<TKey> role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetNormalizedRoleNameAsync(IModularBaseRole<TKey> role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IModularBaseRole<TKey>> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IModularBaseRole<TKey>> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
