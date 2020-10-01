using System;
using System.Data;
using Jlw.Utilities.Data;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    /// <summary>
    ///     EntityType that represents one specific user claim
    /// </summary>
    public class ModularBaseUserClaim : ModularBaseUserClaim<string>
    {
        public ModularBaseUserClaim(IdentityUserClaim<string> claim) : base(claim){}

        public ModularBaseUserClaim(object claim) : base(claim){}

    }

    /// <summary>
    ///     EntityType that represents one specific user claim
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class ModularBaseUserClaim<TKey> : IdentityUserClaim<TKey> where TKey : IEquatable<TKey>
    {
        // Copy Constructor
        public ModularBaseUserClaim(IdentityUserClaim<TKey> claim) 
        {
            CopyFrom(claim);
        }

        public ModularBaseUserClaim(object o) 
        {
            CopyFrom(o);
        }


        public ModularBaseUserClaim<TKey> CopyFrom(IdentityUserClaim<TKey> claim)
        {
            Id = claim.Id;
            UserId = claim.UserId;
            ClaimType = claim.ClaimType;
            ClaimValue = ClaimValue;
            
            return this;
        }

        public ModularBaseUserClaim<TKey> CopyFrom(object o)
        {
            Id = DataUtility.Parse<int>(o, nameof(Id));
            UserId = DataUtility.Parse<TKey>(o, nameof(UserId));
            ClaimType = DataUtility.Parse<string>(o, nameof(ClaimType));
            ClaimValue = DataUtility.Parse<string>(o, nameof(ClaimValue));
            return this;
        }


    }
}
