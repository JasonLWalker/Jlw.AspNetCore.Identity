using System.Collections.Generic;
using Jlw.Utilities.Data;
using Jlw.Utilities.Testing;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;

namespace Jlw.Extensions.Identity.Stores.Tests;

public class ModularBaseUserClaimSchema : BaseModelSchema<ModularBaseUserClaim>
{
    
    public override IEnumerable<InstanceMemberTestData<ModularBaseUserClaim>> InstanceMemberTestList
    {

        get
        {
            int id = 0;
            string userId = String.Empty;
            string claimType = String.Empty;
            string claimValue = String.Empty;
            var sut = new ModularBaseUserClaim(new { });

            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.Id), id, null,
                "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.UserId), userId, null,
                "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.ClaimType), claimType, null,
                "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.ClaimValue), claimValue, null,
                "[Empty Object]");


            id = DataUtility.GenerateRandom<int>();
            userId = DataUtility.GenerateRandom<string>();
            claimType = DataUtility.GenerateRandom<string>();
            claimValue = DataUtility.GenerateRandom<string>();
            sut = new ModularBaseUserClaim(new
                { Id = id, UserId = userId, ClaimType = claimType, ClaimValue = claimValue });

            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.Id), id);
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.UserId), userId);
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.ClaimType), claimType);
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.ClaimValue), claimValue);

            id = DataUtility.GenerateRandom<int>();
            userId = DataUtility.GenerateRandom<string>();
            claimType = DataUtility.GenerateRandom<string>();
            claimValue = DataUtility.GenerateRandom<string>();
            sut = new ModularBaseUserClaim(JToken.Parse(@$"{{  
                ""Id"": {id},
                ""UserId"": ""{userId}"",
                ""ClaimType"": ""{claimType}"",
                ""ClaimValue"": ""{claimValue}"",
            }}"));

            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.Id), id, null, "[Deserialized JSON]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.UserId), userId, null, "[Deserialized JSON]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.ClaimType), claimType, null, "[Deserialized JSON]");
            yield return new InstanceMemberTestData<ModularBaseUserClaim>(sut, nameof(sut.ClaimValue), claimValue, null, "[Deserialized JSON]");


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
        AddProperty(typeof(string), nameof(ModularBaseUserClaim.UserId), Public, Public, false);
        AddProperty(typeof(string), nameof(ModularBaseUserClaim.ClaimType), Public, Public, false);
        AddProperty(typeof(string), nameof(ModularBaseUserClaim.ClaimValue), Public, Public, false);
    }

    protected void InitInterfaces()
    {
    }

    protected void InitConstructors()
    {
        AddConstructor(Public, [typeof(object)]);
        AddConstructor(Public, [typeof(IdentityUserClaim<string>)]);
    }

    public ModularBaseUserClaimSchema()
    {
        InitFields();
        InitProperties();
        InitInterfaces();
        InitConstructors();
    }
}