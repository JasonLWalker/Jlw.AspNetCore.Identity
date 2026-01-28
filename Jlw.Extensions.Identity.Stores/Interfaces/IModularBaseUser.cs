using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

/*
 *
 */

namespace Jlw.Extensions.Identity.Stores
{
    /// <summary>
    /// Shim to support legacy code should use Interface from Jlw.Extensions.Identity
    /// </summary>
    public interface IModularBaseUser : IModularBaseUser<string>, Jlw.Extensions.Identity.IModularBaseUser
    {

    }

    /// <summary>
    /// Shim to support legacy code should use Interface from Jlw.Extensions.Identity
    /// </summary>
    public interface IModularBaseUser<TKey> : IModularBaseUser<TKey, IdentityUserClaim<TKey>>, Jlw.Extensions.Identity.IModularBaseUser<TKey, IdentityUserClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
    }

    /// <summary>
    /// Shim to support legacy code should use Interface from Jlw.Extensions.Identity
    /// </summary>
    public interface IModularBaseUser<TKey, TClaim> : Jlw.Extensions.Identity.IModularBaseUser<TKey, TClaim>
        where TKey : IEquatable<TKey>
    {
    }
}