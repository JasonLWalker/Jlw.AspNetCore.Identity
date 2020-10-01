using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    public interface IModularBaseUser : IModularBaseUser<string>
    {

    }

    public interface IModularBaseUser<TKey> : IModularBaseUser<TKey, IdentityUserClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
    }

    public interface IModularBaseUser<TKey, TClaim>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
        string UserName { get; set; }
        string NormalizedUserName { get; set; }

        string Email { get; set; }
        string NormalizedEmail { get; set; }
        bool EmailConfirmed { get; set; }


        string PasswordHash { get; set; }

        string PhoneNumber { get; set; }
        bool PhoneNumberConfirmed { get; set; }

        bool TwoFactorEnabled { get; set; }

        int AccessFailedCount { get; set; }

        bool LockoutEnabled { get; set; }

        DateTimeOffset? LockoutEnd { get; set; }

        ICollection<TClaim> Claims { get; }

        IModularBaseUser<TKey, TClaim> CopyFrom(IModularBaseUser<TKey, TClaim> o);

        IModularBaseUser<TKey, TClaim> CopyFrom(object o);
    }
}