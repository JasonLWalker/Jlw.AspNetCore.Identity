using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jlw.Extensions.Identity.Stores
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUser : IdentityUser<string>
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string userName) : this()
        {
            UserName = userName;
        }

    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUser<TKey> : IdentityUser<TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>, IdentityUserLogin<TKey>>
        where TKey : IEquatable<TKey>
    { }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin> : Microsoft.AspNetCore.Identity.IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        // ReSharper disable once InconsistentNaming
        protected readonly IList<TUserRole> _roles = new List<TUserRole>();
        // ReSharper disable once InconsistentNaming
        protected readonly IList<TUserClaim> _claims = new List<TUserClaim>();
        // ReSharper disable once InconsistentNaming
        protected readonly IList<TUserLogin> _logins = new List<TUserLogin>();
        public IdentityUser() { }

        public IdentityUser(string userName) : this()
        {
            UserName = userName;
        }

        [JsonProperty(PropertyName = "id")]
        public override TKey Id
        {
            get => base.Id;
            set
            {
                base.Id = value;
            }
        }

        [JsonProperty("userName")]
        public override string UserName { get; set; }

        [JsonProperty("normalizedUserName")]
        public override string NormalizedUserName { get; set; }

        [JsonProperty("email")]
        public override string Email { get; set; }

        [JsonProperty("normalizedEmail")]
        public override string NormalizedEmail { get; set; }

        [JsonProperty("emailConfirmed")]
        public override bool EmailConfirmed { get; set; }

        [JsonProperty("passwordHash")]
        public override string PasswordHash { get; set; }

        [JsonProperty("securityStamp")]
        public override string SecurityStamp { get; set; }

        [JsonProperty("concurrencyStamp")]
        public override string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("phoneNumber")]
        public override string PhoneNumber { get; set; }

        [JsonProperty("phoneNumberConfirmed")]
        public override bool PhoneNumberConfirmed { get; set; }

        [JsonProperty("twoFactorEnabled")]
        public override bool TwoFactorEnabled { get; set; }

        [JsonProperty("lockoutEnd")]
        public override DateTimeOffset? LockoutEnd { get; set; }

        [JsonProperty("lockoutEnabled")]
        public override bool LockoutEnabled { get; set; }

        [JsonProperty("accessFailedCount")]
        public override int AccessFailedCount { get; set; }


        [JsonProperty("roles")]
        public virtual IEnumerable<TUserRole> Roles => _roles;

        [JsonProperty("claims")]
        public virtual IEnumerable<TUserClaim> Claims => _claims;

        [JsonProperty("logins")]
        public virtual IEnumerable<TUserLogin> Logins => _logins;

        public override string ToString()
        {
            return UserName;
        }
    }
}
