using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jlw.Utilities.Data.DbUtility;
using Microsoft.AspNetCore.Identity;

namespace Jlw.Extensions.Identity.Stores
{
    class RoleStore : RoleStore<string>
    {
        public RoleStore(IModularDbClient dbClient, IdentityErrorDescriber describer) : base(dbClient, describer) { }
    }

    class RoleStore<TKey> : RoleStoreBase<TKey> where TKey : IEquatable<TKey>
    {
        protected readonly IModularDbClient DbClient;

        public RoleStore(IModularDbClient dbClient, Microsoft.AspNetCore.Identity.IdentityErrorDescriber describer) : base(describer)
        {
            DbClient = dbClient;
        }
    }
}
