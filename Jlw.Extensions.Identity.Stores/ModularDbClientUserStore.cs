using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Jlw.Utilities.Data;
using Jlw.Utilities.Data.DbUtility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Jlw.Extensions.Identity.Stores
{
    public class ModularDbClientUserStore<TUser, TKey> : ModularUserStoreBase<TUser, TKey>, IModularDataRepository<TUser, TUser>
        where TUser : ModularBaseUser<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        #region Members
        private readonly IModularDbClient _dbClient;
        private string _connString => _builder.ConnectionString;

        protected DbConnectionStringBuilder _builder { get; }
        protected IDictionary<string, RepositoryMethodDefinition<TUser, TUser>> _definitions = new Dictionary<string, RepositoryMethodDefinition<TUser, TUser>>();

        public DbConnectionStringBuilder ConnectionBuilder => _builder;
        public string ConnectionString => _builder.ConnectionString;
        public IModularDbClient DbClient => _dbClient;
        #endregion



        public ModularDbClientUserStore(string connString, IModularDbClient dbClient)
        {
            _dbClient = dbClient;
            _builder = _dbClient.GetConnectionBuilder(connString);
            InitializeDefinitions();
        }

        
        #region Repository Methods
        protected virtual void InitializeDefinitions()
        {
            AddDefinition("FindByNameAsync", new RepositoryMethodDefinition<TUser, TUser>("sp_AuthFindUserByName", CommandType.StoredProcedure, new[] { "normalizedUserName" }, null, typeof(TUser)));
        }
        
        public static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }

        protected internal RepositoryMethodDefinition<TUser, TUser> GetDefinition(string key)
        {
            return _definitions.FirstOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Value;
        }

        protected internal RepositoryMethodDefinition<TUser, TUser> AddDefinition(string name, RepositoryMethodDefinition<TUser, TUser> definition)
        {
            _definitions.Add(name, definition);
            return _definitions[name];
        }

        protected internal TReturn GetRecordObject<TReturn>(TUser objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordObject<TUser, TUser, TReturn>(objSearch, ConnectionString, def);

        }

        protected internal object GetRecordScalar(TUser objSearch, string definitionName) => GetRecordScalar<object>(objSearch, definitionName);

        protected internal TReturn GetRecordScalar<TReturn>(TUser objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordScalar<TUser, TUser, TReturn>(objSearch, ConnectionString, def);

        }
        #endregion


        #region Common Database Methods

        /// <summary>
        /// Creates the specified <paramref name="user" /> in the user store.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the creation operation.</returns>
        public override Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);

            // Check for valid data
            if (!string.IsNullOrWhiteSpace(user.Id.ToString()) && user.Id.ToString() != "0")
                throw new ArgumentException($"Invalid argument. Id must not be specified.", nameof(user.Id), null);
            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException($"Invalid argument. UserName cannot be null or empty.", nameof(user.UserName), null);
            if (string.IsNullOrWhiteSpace(user.NormalizedUserName))
                throw new ArgumentException($"Invalid argument. Normalized UserName cannot be null or empty.", nameof(user.NormalizedUserName), null);

            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthCreateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _dbClient.AddParameterWithValue("@userName", user.UserName, cmd);
                _dbClient.AddParameterWithValue("@normalizedUserName", user.NormalizedUserName, cmd);
                _dbClient.AddParameterWithValue("@email", user.Email, cmd);
                _dbClient.AddParameterWithValue("@normalizedEmail", user.NormalizedEmail, cmd);
                _dbClient.AddParameterWithValue("@emailConfirmed", user.EmailConfirmed, cmd);
                _dbClient.AddParameterWithValue("@passwordHash", user.PasswordHash, cmd);
                _dbClient.AddParameterWithValue("@phoneNumber", user.PhoneNumber, cmd);
                _dbClient.AddParameterWithValue("@phoneNumberConfirmed", user.PhoneNumberConfirmed, cmd);
                _dbClient.AddParameterWithValue("@accessFailedCount", user.AccessFailedCount, cmd);
                _dbClient.AddParameterWithValue("@lockoutEnabled", user.LockoutEnabled, cmd);
                _dbClient.AddParameterWithValue("@lockoutEnd", user.LockoutEnd, cmd);
                _dbClient.AddParameterWithValue("@twoFactorEnabled", user.TwoFactorEnabled, cmd);
                
                conn.Open();
                string result = cmd.ExecuteScalar().ToString();
                switch (result.ToLower())
                {
//                    case "success":
//                        break;
//                    case "duplicate id":
//                        throw new ArgumentException($"Cannot add a duplicate record. Id is already in use.", nameof(user.Id), null);
                    case "duplicate username":
                        throw new ArgumentException($"Cannot add a duplicate record. UserName is already in use.", nameof(user.UserName), null);
                    case "duplicate normalized username":
                        throw new ArgumentException($"Cannot add a duplicate record. Normalized UserName is already in use.", nameof(user.NormalizedUserName), null);
                }

                if (string.IsNullOrWhiteSpace(user.Id.ToString()) && DataUtility.ParseInt(result) > 0)
                {
                    user.Id = DataUtility.Parse<TKey>(result);
                }

                conn.Close();
            }

            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// Deletes the specified <paramref name="user" /> from the user store.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the update operation.</returns>
        public override Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);

            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);

            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthDeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _dbClient.AddParameterWithValue("@id", user.Id, cmd);
                
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
            }

            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// Updates the specified <paramref name="user" /> in the user store.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the update operation.</returns>
        public override Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);

            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);
            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException($"Invalid argument. UserName cannot be null or empty.", nameof(user.UserName), null);
            if (string.IsNullOrWhiteSpace(user.NormalizedUserName))
                throw new ArgumentException($"Invalid argument. Normalized UserName cannot be null or empty.", nameof(user.NormalizedUserName), null);

            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthUpdateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _dbClient.AddParameterWithValue("@id", user.Id, cmd);
                _dbClient.AddParameterWithValue("@userName", user.UserName, cmd);
                _dbClient.AddParameterWithValue("@normalizedUserName", user.NormalizedUserName, cmd);
                _dbClient.AddParameterWithValue("@email", user.Email, cmd);
                _dbClient.AddParameterWithValue("@normalizedEmail", user.NormalizedEmail, cmd);
                _dbClient.AddParameterWithValue("@emailConfirmed", user.EmailConfirmed, cmd);
                _dbClient.AddParameterWithValue("@passwordHash", user.PasswordHash, cmd);
                _dbClient.AddParameterWithValue("@phoneNumber", user.PhoneNumber, cmd);
                _dbClient.AddParameterWithValue("@phoneNumberConfirmed", user.PhoneNumberConfirmed, cmd);
                _dbClient.AddParameterWithValue("@accessFailedCount", user.AccessFailedCount, cmd);
                _dbClient.AddParameterWithValue("@lockoutEnabled", user.LockoutEnabled, cmd);
                if (user.LockoutEnd != null)
                    _dbClient.AddParameterWithValue("@lockoutEnd", user.LockoutEnd.Value, cmd);
                else
                    _dbClient.AddParameterWithValue("@lockoutEnd", DBNull.Value, cmd);
                _dbClient.AddParameterWithValue("@twoFactorEnabled", user.TwoFactorEnabled, cmd);
                
                conn.Open();
                string result = cmd.ExecuteScalar().ToString();
                switch (result.ToLower())
                {
                    case "success":
                        break;
                    case "duplicate username":
                        throw new ArgumentException($"Cannot add a duplicate record. UserName is already in use.", nameof(user.UserName), null);
                    case "duplicate normalized username":
                        throw new ArgumentException($"Cannot add a duplicate record. Normalized UserName is already in use.", nameof(user.NormalizedUserName), null);
                }

                conn.Close();
            }




            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// Finds and returns a user, if any, who has the specified <paramref name="userId" />.
        /// </summary>
        /// <param name="userId">The user ID to search for.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="userId" /> if it exists.
        /// </returns>
        public override Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            TUser oResult = null;
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthFindUserById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                _dbClient.AddParameterWithValue("@id", userId, cmd);
                
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        oResult = new TUser();
                        oResult.CopyFrom(rdr);
                    }
                }
            }

            return Task.FromResult(oResult);
        }

        /// <summary>
        /// Finds and returns a user, if any, who has the specified normalized user name.
        /// </summary>
        /// <param name="normalizedUserName">The normalized user name to search for.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="normalizedUserName" /> if it exists.
        /// </returns>
        public override Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            /*
            TUser oResult = null;
            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthFindUserByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                _dbClient.AddParameterWithValue("@normalizedUserName", normalizedUserName, cmd);
                
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        oResult = new TUser();
                        oResult.CopyFrom(rdr);
                    }
                }

            }

            return Task.FromResult(oResult);
            */
            return Task.FromResult(GetRecordObject<TUser>(new TUser(){ NormalizedUserName = normalizedUserName }, GetCaller()));
        }

        #endregion

        /// <inheritdoc />
        public override Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!string.IsNullOrWhiteSpace(user.Id.ToString()))
                return Task.FromResult(user.Id.ToString());

            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthGetIdByUserName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                _dbClient.AddParameterWithValue("@normalizedUserName", user.NormalizedUserName, cmd);
                
                conn.Open();
                user.Id = DataUtility.Parse<TKey>(cmd.ExecuteScalar());

            }

            return Task.FromResult(user.Id.ToString());

        }

        #region Role Methods
        /// <inheritdoc />
        public override Task AddToRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);

            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException($"Invalid argument. Role cannot be null or empty.", nameof(roleName), null);

            var normalizedRoleName = roleName.ToUpper();
            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthAddUserToRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                _dbClient.AddParameterWithValue("@id", user.Id, cmd);
                _dbClient.AddParameterWithValue("@normalizedRoleName", normalizedRoleName, cmd);
                
                conn.Open();
                string result = cmd.ExecuteScalar().ToString();
                switch (result.ToLower())
                {
                    case "success":
                    case "already in role":
                        break;
                    case "user not found":
                        //throw new ArgumentException($"Cannot add a duplicate record. UserName is already in use.", nameof(user.UserName), null);
                        break;
                }

                conn.Close();
            }
            return Task.FromResult(0);

        }

        /// <inheritdoc />
        public override Task<bool> IsInRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            bool oResult;
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);

            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException($"Invalid argument. Role cannot be null or empty.", nameof(roleName), null);


            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthIsUserInRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var normalizedRoleName = roleName.ToUpper();
                _dbClient.AddParameterWithValue("@id", DataUtility.ParseInt(user.Id), cmd);
                _dbClient.AddParameterWithValue("@normalizedRoleName", normalizedRoleName, cmd);
                
                conn.Open();
                oResult = DataUtility.ParseBool(cmd.ExecuteScalar());

            }

            return Task.FromResult(oResult);
        }

        /// <inheritdoc />
        public override Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken)
        {
            ThrowIfNullDisposedCancelled(user, cancellationToken);
//            cancellationToken.ThrowIfCancellationRequested();

            IList<string> roles = new List<string>();
/*
            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);
*/
            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);

            using (var conn = _dbClient.GetConnection(_connString))
            {
                var cmd = _dbClient.GetCommand("sp_AuthGetRolesForUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                _dbClient.AddParameterWithValue("@id", DataUtility.ParseInt(user.Id), cmd);
                
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        roles.Add(rdr["RoleName"].ToString());
                    }
                }

            }
            
            return Task.FromResult(roles);
        }

        /// <inheritdoc />
        public override Task<IList<TUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            IList<TUser> oResult = new List<TUser>();

            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException($"Invalid argument. Role cannot be null or empty.", nameof(roleName), null);

            var normalizedRoleName = roleName.ToUpper();

            using (var conn = _dbClient.GetConnection(_connString))
            {
                var cmd = _dbClient.GetCommand("sp_AuthGetUsersInRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                _dbClient.AddParameterWithValue("@normalizedRoleName", normalizedRoleName, cmd);
                
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var u = new TUser();
                        u.CopyFrom(rdr);

                        oResult.Add(u);
                    }
                }

            }
            
            return Task.FromResult(oResult);
        }

        /// <inheritdoc />
        public override Task RemoveFromRoleAsync(TUser user, string roleName, CancellationToken cancellationToken)
        {
            ThrowIfNullDisposedCancelled(user, cancellationToken);

            /*
            if (user == null)
                throw new ArgumentException($"Invalid argument. User cannot be null.", nameof(user), null);
            */

            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);

            var normalizedRoleName = roleName.ToUpper();
            using (var conn = _dbClient.GetConnection(_connString))
            {
                IDbCommand cmd = _dbClient.GetCommand("sp_AuthRemoveUserFromRole", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                _dbClient.AddParameterWithValue("@id", user.Id, cmd);
                _dbClient.AddParameterWithValue("@normalizedRoleName", normalizedRoleName, cmd);
                
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
            }

            return Task.FromResult(IdentityResult.Success);
        }
        
        #endregion

        /// <inheritdoc />
        public override Task<IList<Claim>> GetClaimsAsync(TUser user, CancellationToken cancellationToken = new CancellationToken())
        {
            ThrowIfNullDisposedCancelled(user, cancellationToken);
            var aList = user.Claims.ToList();
            user.Claims.Clear();

            // Check for valid data
            if (string.IsNullOrWhiteSpace(user.Id.ToString()))
                throw new ArgumentException($"Invalid argument. Id cannot be null or empty.", nameof(user.Id), null);

            using (var conn = _dbClient.GetConnection(_connString))
            {
                var cmd = _dbClient.GetCommand("sp_AuthGetClaimsForUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                _dbClient.AddParameterWithValue("@id", DataUtility.ParseInt(user.Id), cmd);
                
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Type t = user.Claims.GetType().GetTypeInfo().GenericTypeArguments[0];
                        dynamic claim = Activator.CreateInstance(typeof(ModularBaseUserClaim<>).MakeGenericType(user.Id.GetType()), rdr);
                        
                        user.Claims.Add(claim);
                    }
                }

            }

            return base.GetClaimsAsync(user, cancellationToken);
            //return Task.FromResult(user.Claims.ToList());

        }


        public override Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.FromResult(GetRecordObject<TUser>(null, GetCaller()));
        }
    }
}
