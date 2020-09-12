using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Jlw.Extensions.Identity.Stores
{
    public class RoleStoreBase : RoleStoreBase<string>
    {
        public RoleStoreBase(Microsoft.AspNetCore.Identity.IdentityErrorDescriber describer) : base(describer) { }

    }

    public class RoleStoreBase<TKey> : RoleStoreBase<IdentityRole<TKey>, TKey, IdentityUserRole<TKey>, IdentityRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        public RoleStoreBase(Microsoft.AspNetCore.Identity.IdentityErrorDescriber describer) : base(describer) { }

    }

    public class RoleStoreBase<TRole, TKey, TUserRole, TRoleClaim> : Microsoft.AspNetCore.Identity.RoleStoreBase<TRole, TKey, TUserRole, TRoleClaim>
        where TRole : IdentityRole<TKey, TUserRole, TRoleClaim>, new()
        where TKey : IEquatable<TKey>
        where TUserRole : IdentityUserRole<TKey>, new()
        where TRoleClaim : IdentityRoleClaim<TKey>, new()

    {

        public new void Dispose()
        {
            base.Dispose();
        }

        public override Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TRole> Roles { get; }


        public override Task<Microsoft.AspNetCore.Identity.IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<Microsoft.AspNetCore.Identity.IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<Microsoft.AspNetCore.Identity.IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public RoleStoreBase(Microsoft.AspNetCore.Identity.IdentityErrorDescriber describer) : base(describer)
        {
        }
    }
}
