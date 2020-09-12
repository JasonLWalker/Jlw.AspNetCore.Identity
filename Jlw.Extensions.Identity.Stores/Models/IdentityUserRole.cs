using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jlw.Extensions.Identity.Stores
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUserRole<TKey> : Microsoft.AspNetCore.Identity.IdentityUserRole<TKey>
        where TKey : IEquatable<TKey>
    {
        [JsonProperty("userId")]
        public override TKey UserId { get; set; }

        [JsonProperty("roleId")]
        public override TKey RoleId { get; set; }
    }
}
