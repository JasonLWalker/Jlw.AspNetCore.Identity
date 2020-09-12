using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Extensions.Identity.Stores
{
    public class UserStore : UserStore<IdentityUser>
    {
        public UserStore(ModularUserStoreRepo<IdentityUser> dbRepo) : base(dbRepo) { }

    }

    public class UserStore<TUser> : UserStore<TUser, string>
        where TUser : IdentityUser, new()
    {
        public UserStore(ModularUserStoreRepo<TUser, string> dbRepo) : base(dbRepo) {}

    }

    public class UserStore<TUser, TKey> : UserStoreBase<TUser, TKey>
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        protected readonly ModularUserStoreRepo<TUser, TKey> DbRepo;

        public UserStore(ModularUserStoreRepo<TUser, TKey> dbRepo) : base()
        {
            DbRepo = dbRepo;
        }

        public override Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return new Task<TUser>(() => DbRepo.GetRecord(new TUser { Id = ConvertIdFromString(userId) }));
        }
    }
}
