using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jlw.Extensions.Identity.Stores
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityRole : IdentityRole<string>
    {

        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityRole<TKey> : IdentityRole<TKey, IdentityUserRole<TKey>, IdentityRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityRole<TKey, TUserRole, TRoleClaim> : Microsoft.AspNetCore.Identity.IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
    {
        // ReSharper disable once InconsistentNaming
        protected readonly IList<TRoleClaim> _claims = new List<TRoleClaim>();
        public IdentityRole() { }

        [JsonProperty(PropertyName = "id")]
        public override TKey Id
        {
            get => base.Id;
            set
            {
                base.Id = value;
            }
        }

        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }


        [JsonProperty(PropertyName = "claims")]
        public virtual IEnumerable<TRoleClaim> Claims => _claims;


        [JsonProperty(PropertyName = "name")]
        public override string Name { get; set; }

        [JsonProperty(PropertyName = "normalizedName")]
        public override string NormalizedName { get; set; }

        [JsonProperty(PropertyName = "concurrencyStamp")]
        public override string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return Name;
        }
    }
}
