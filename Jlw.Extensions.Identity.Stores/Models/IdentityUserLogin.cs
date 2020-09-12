using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jlw.Extensions.Identity.Stores
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUserLogin<TKey> : Microsoft.AspNetCore.Identity.IdentityUserLogin<TKey>
        where TKey : IEquatable<TKey>
    {
        public override string LoginProvider { get; set; }

        public override string ProviderKey { get; set; }

        public override string ProviderDisplayName { get; set; }

        public override TKey UserId { get; set; }
    }
}
