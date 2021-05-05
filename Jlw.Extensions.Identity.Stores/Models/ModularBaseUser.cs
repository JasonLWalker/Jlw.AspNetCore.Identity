using System;
using System.Collections.Generic;
using System.Data;
using Jlw.Utilities.Data;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{

    public class ModularBaseUser : ModularBaseUser<string>, IModularBaseUser
    {
        public ModularBaseUser() : base()
        {
        }

        public ModularBaseUser(IModularBaseUser data) : base(data)
        {
        }

        public ModularBaseUser(object o) : base(o)
        {
        }
    }
    
    public class ModularBaseUser<TKey> : ModularBaseUser<TKey, IdentityUserClaim<TKey>>, IModularBaseUser<TKey>
        where TKey : IEquatable<TKey>
    {
        public ModularBaseUser() : base()
        {

        }

        public ModularBaseUser(IModularBaseUser<TKey> data) : base(data)
        {

        }

        public ModularBaseUser(object o) : base(o)
        {
        }
    }
        

    public class ModularBaseUser<TKey, TClaim> : IdentityUser<TKey>, IModularBaseUser<TKey, TClaim>
        where TKey : IEquatable<TKey>
        where TClaim : IdentityUserClaim<TKey>
    {

        public override string SecurityStamp
        {
            get => base.SecurityStamp ?? (base.SecurityStamp = Guid.NewGuid().ToString());
            set => base.SecurityStamp = value;
        }

        /// <summary>
        /// The user's claims, for use in claims-based authentication.
        /// </summary>
        public virtual ICollection<TClaim> Claims { get; private set; } = new List<TClaim>();

        public ModularBaseUser() 
        {
        }

        // Copy Constructor
        public ModularBaseUser(IModularBaseUser<TKey, TClaim> user) 
        {
            CopyFrom(user);
        }

        public ModularBaseUser(object o) 
        {
            CopyFrom(o);
        }

        public IModularBaseUser<TKey, TClaim> CopyFrom(IModularBaseUser<TKey, TClaim> user)
        {
            Id = user.Id;
            UserName = user.UserName;
            NormalizedUserName = user.NormalizedUserName;
            Email = user.Email;
            NormalizedEmail = user.NormalizedEmail;
            EmailConfirmed = user.EmailConfirmed;
            PasswordHash = user.PasswordHash;
            PhoneNumber = user.PhoneNumber;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            AccessFailedCount = user.AccessFailedCount;
            LockoutEnabled = user.LockoutEnabled;
            LockoutEnd = user.LockoutEnd;
            TwoFactorEnabled = user.TwoFactorEnabled;
            
            return this;
        }

        public IModularBaseUser<TKey, TClaim> CopyFrom(object o)
        {
            var t = typeof(TKey);
            Id = DataUtility.Parse<TKey>(o, nameof(Id));
            UserName = DataUtility.Parse<string>(o, nameof(UserName));
            NormalizedUserName = DataUtility.Parse<string>(o, nameof(NormalizedUserName));
            Email = DataUtility.Parse<string>(o, nameof(Email));
            NormalizedEmail = DataUtility.Parse<string>(o, nameof(NormalizedEmail));
            EmailConfirmed = DataUtility.Parse<bool>(o, nameof(EmailConfirmed));
            PasswordHash = DataUtility.Parse<string>(o, nameof(PasswordHash));
            PhoneNumber = DataUtility.Parse<string>(o, nameof(PhoneNumber));
            PhoneNumberConfirmed = DataUtility.Parse<bool>(o, nameof(PhoneNumberConfirmed));
            AccessFailedCount = DataUtility.Parse<int>(o, nameof(AccessFailedCount));
            LockoutEnabled = DataUtility.Parse<bool>(o, nameof(LockoutEnabled));
            LockoutEnd = DataUtility.Parse<DateTimeOffset?>(o, nameof(LockoutEnd));
            TwoFactorEnabled = DataUtility.Parse<bool>(o, nameof(TwoFactorEnabled));

            return this;
        }

    }
}
