using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

/*
    Based on code originally from the .net sample code found here:
    https://github.com/aspnet/Security/blob/22d2fe99c6fd9806b36025399a217a3a8b4e50f4/samples/CookieSessionSample/MemoryCacheTicketStore.cs
    and later here:
    https://github.com/dotnet/aspnetcore/blob/main/src/Security/Authentication/Cookies/samples/CookieSessionSample/MemoryCacheTicketStore.cs
*/

namespace Jlw.Extensions.Identity
{
    public class MemoryCacheTicketStore : ITicketStore
    {
        private readonly IMemoryCache _cache;
        private string _keyPrefix = "JlwAuthSessionStore-";
        private TimeSpan _slidingExpirationDuration = TimeSpan.FromHours(1);

        public string KeyPrefix
        {
            get => _keyPrefix;
            set => _keyPrefix = value;
        }

        public TimeSpan SlidingExpirationDuration
        {
            get => _slidingExpirationDuration;
            set => _slidingExpirationDuration = value;
        }

        public MemoryCacheTicketStore()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<string> StoreAsync(AuthenticationTicket ticket)
        {
            var guid = Guid.NewGuid();
            var key = _keyPrefix + guid.ToString();
            await RenewAsync(key, ticket);
            return key;
        }

        public Task RenewAsync(string key, AuthenticationTicket ticket)
        {
            var options = new MemoryCacheEntryOptions();
            var expiresUtc = ticket.Properties.ExpiresUtc;
            if (expiresUtc.HasValue)
            {
                options.SetAbsoluteExpiration(expiresUtc.Value);
            }
            options.SetSlidingExpiration(_slidingExpirationDuration);

            _cache.Set(key, ticket, options);

            return Task.FromResult(0);
        }

        public Task<AuthenticationTicket> RetrieveAsync(string key)
        {
            AuthenticationTicket ticket;
            _cache.TryGetValue(key, out ticket);
            return Task.FromResult(ticket);
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            return Task.FromResult(0);
        }

    }
}
