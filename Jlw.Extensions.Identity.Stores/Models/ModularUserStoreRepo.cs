using System;
using System.Collections.Generic;
using System.Text;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Extensions.Identity.Stores
{
    public class ModularUserStoreRepo<TUser> : ModularUserStoreRepo<TUser, string>
        where TUser : IdentityUser<string>, new()
    {
        public ModularUserStoreRepo(IModularDbClient dbClient, string connString) : base(dbClient, connString)
        {

        }

    }

    public class ModularUserStoreRepo<TUser, TKey> : ModularDataRepositoryBase<TUser, TUser>
        where TUser : IdentityUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        public ModularUserStoreRepo(IModularDbClient dbClient, string connString) : base(dbClient, connString)
        {

        }

        public TUser GetRecord(TUser o)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUser> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public TUser InsertRecord(TUser o)
        {
            throw new NotImplementedException();
        }

        public TUser SaveRecord(TUser o)
        {
            throw new NotImplementedException();
        }

        public TUser UpdateRecord(TUser o)
        {
            throw new NotImplementedException();
        }

        public TUser DeleteRecord(TUser o)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, string>> GetKvpList()
        {
            throw new NotImplementedException();
        }
    }
}
