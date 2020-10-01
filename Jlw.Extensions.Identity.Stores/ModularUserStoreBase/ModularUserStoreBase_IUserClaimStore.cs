using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{

    public partial class ModularUserStoreBase<TUser, TKey, TUserClaim, TUserLogin> : IUserClaimStore<TUser>
    {
        public override Task<IList<Claim>> GetClaimsAsync(TUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            var claims = user.Claims.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList();
            return Task.FromResult<IList<Claim>>(claims);
        }

        public override Task AddClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var claim in claims)
            {
                user.Claims.Add(new TUserClaim() { ClaimType = claim.Type, ClaimValue = claim.Value, UserId = user.Id });
            }
            return Task.FromResult(0);
        }

        public override Task ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var matchedClaims = user.Claims.Where(uc => uc.ClaimValue == claim.Value && uc.ClaimType == claim.Type).ToList();
            foreach (var matchedClaim in matchedClaims)
            {
                matchedClaim.ClaimValue = newClaim.Value;
                matchedClaim.ClaimType = newClaim.Type;
            }
            return Task.FromResult(0);
        }

        public override Task RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var claim in claims)
            {
                var entity =
                    user.Claims.FirstOrDefault(
                        uc => uc.UserId.ToString() == user.Id.ToString() && uc.ClaimType == claim.Type && uc.ClaimValue == claim.Value);
                if (entity != null)
                {
                    user.Claims.Remove(entity);
                }
            }
            return Task.FromResult(0);
        }

        public override Task<IList<TUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }

            var query = from user in Users
                where user.Claims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value) != null
                select user;

            return Task.FromResult<IList<TUser>>(query.ToList());
        }

    }

}
