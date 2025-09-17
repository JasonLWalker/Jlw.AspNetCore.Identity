using System.Collections.Generic;
using Jlw.Utilities.Data;
using Jlw.Utilities.Testing;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;

namespace Jlw.Extensions.Identity.Stores.Tests;

public class ModularBaseUserClaimSchema<T> : BaseModelSchema<ModularBaseUserClaim<T>> where T : IEquatable<T>
{
    
    public override IEnumerable<InstanceMemberTestData<ModularBaseUserClaim<T>>> InstanceMemberTestList
    {

        get
        {
            int id = 0;
            T userId = DataUtility.Parse<T>(default);
            string claimType = String.Empty;
            string claimValue = String.Empty;
            var sut = new ModularBaseUserClaim<T>(new { });

            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.Id), id, null, "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.UserId), userId, null, "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.ClaimType), claimType, null, "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.ClaimValue), claimValue, null, "[Empty Object]");


            id = DataUtility.GenerateRandom<int>();
            userId = DataUtility.GenerateRandom<T>();
            claimType = DataUtility.GenerateRandom<string>();
            claimValue = DataUtility.GenerateRandom<string>();
            sut = new ModularBaseUserClaim<T>(new { Id = id, UserId = userId, ClaimType = claimType, ClaimValue = claimValue });

            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.Id), id);
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.UserId), userId);
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.ClaimType), claimType);
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.ClaimValue), claimValue);

            id = DataUtility.GenerateRandom<int>();
            userId = DataUtility.GenerateRandom<T>();
            claimType = DataUtility.GenerateRandom<string>();
            claimValue = DataUtility.GenerateRandom<string>();
            sut = new ModularBaseUserClaim<T>(JToken.Parse(@$"{{  
                ""Id"": {id},
                ""UserId"": ""{userId}"",
                ""ClaimType"": ""{claimType}"",
                ""ClaimValue"": ""{claimValue}"",
            }}"));

            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.Id), id, null, "[Deserialized JSON]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.UserId), userId, null, "[Deserialized JSON]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.ClaimType), claimType, null, "[Deserialized JSON]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim<T>>(sut, nameof(sut.ClaimValue), claimValue, null, "[Deserialized JSON]");


            // Pick up any values not tested
            foreach (var baseVal in base.InstanceMemberTestList)
            {
                yield return baseVal;
            }
        }
    }
    

    protected void InitFields()
    {
        
    }

    protected void InitProperties()
    {
        AddProperty(typeof(int), nameof(ModularBaseUserClaim.Id), Public, Public, false);
        AddProperty(typeof(T), nameof(ModularBaseUserClaim.UserId), Public, Public, false);
        AddProperty(typeof(string), nameof(ModularBaseUserClaim.ClaimType), Public, Public, false);
        AddProperty(typeof(string), nameof(ModularBaseUserClaim.ClaimValue), Public, Public, false);
    }

    protected void InitInterfaces()
    {
    }

    protected void InitConstructors()
    {
        AddConstructor(Public, [typeof(object)]);
        AddConstructor(Public, [typeof(IdentityUserClaim<T>)]);
    }

    public ModularBaseUserClaimSchema()
    {
        InitFields();
        InitProperties();
        InitInterfaces();
        InitConstructors();
    }
}