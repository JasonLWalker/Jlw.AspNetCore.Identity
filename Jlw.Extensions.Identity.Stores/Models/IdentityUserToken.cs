using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jlw.Extensions.Identity.Stores
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUserToken : IdentityUserToken<string>
    {
        public IdentityUserToken()
        {
            Id = Guid.NewGuid().ToString();
        }
    }


    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class IdentityUserToken<TKey> : Microsoft.AspNetCore.Identity.IdentityUserToken<TKey>
        where TKey : IEquatable<TKey>
    {
        // ReSharper disable once InconsistentNaming
        protected TKey _Id;

        [JsonProperty(PropertyName = "id")]
        public TKey Id
        {
            get => _Id;
            set
            {
                _Id = value;
            }
        }

        [JsonProperty("userId")]
        public override TKey UserId { get; set; }

        [JsonProperty("loginProvider")]
        public override string LoginProvider { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("value")]
        public override string Value { get; set; }
    }
}
