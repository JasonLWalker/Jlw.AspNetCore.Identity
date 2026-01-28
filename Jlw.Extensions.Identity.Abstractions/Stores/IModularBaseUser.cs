using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

namespace Jlw.Extensions.Identity.Stores
{
    public interface IModularBaseUser : IModularBaseUser<string>, Jlw.Extensions.Identity.IModularBaseUser
    {

    }

    public interface IModularBaseUser<TKey> : IModularBaseUser<TKey, IdentityUserClaim<TKey>>, Jlw.Extensions.Identity.IModularBaseUser<TKey, IdentityUserClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
    }

    public interface IModularBaseUser<TKey, TClaim> : Jlw.Extensions.Identity.IModularBaseUser<TKey, TClaim>
        where TKey : IEquatable<TKey>
    {
    }
}