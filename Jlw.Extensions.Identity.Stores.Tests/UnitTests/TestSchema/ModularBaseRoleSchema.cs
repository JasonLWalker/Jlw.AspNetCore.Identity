using Jlw.Utilities.Data;
using Jlw.Utilities.Testing;

namespace Jlw.Extensions.Identity.Stores.Tests;

public class ModularBaseRoleSchema : BaseModelSchema<ModularBaseRole>
{
    public override IEnumerable<InstanceMemberTestData<ModularBaseRole>> InstanceMemberTestList
    {
        get
        {
            int id = 0;
            string? name = null;
            string? normalizedName = null;
            var sut = new ModularBaseRole();

            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.Id), id, null, "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.Name), name, null, "[Empty Object]");
            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.NormalizedName), normalizedName, null, "[Empty Object]");

            id = DataUtility.GenerateRandom<int>();
            name = DataUtility.GenerateRandom<string>();
            normalizedName = DataUtility.GenerateRandom<string>();
            sut = new ModularBaseRole { Id = id, Name = name, NormalizedName = normalizedName };

            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.Id), id);
            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.Name), name);
            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.NormalizedName), normalizedName);

            /*
            id = DataUtility.GenerateRandom<int>();
            name = DataUtility.GenerateRandom<string>();
            normalizedName = DataUtility.GenerateRandom<string>();
            sut = new ModularBaseRole(new { Id = id, Name = name, NormalizedName = normalizedName });

            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.Id), id, null, "[Anonymous Object]");
            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.Name), name, null, "[Anonymous Object]");
            yield return new InstanceMemberTestData<ModularBaseRole>(sut, nameof(sut.NormalizedName), normalizedName, null, "[Anonymous Object]");
            */
            
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
        AddProperty(typeof(int), nameof(ModularBaseRole.Id), Public, Public, false);
        AddProperty(typeof(string), nameof(ModularBaseRole.Name), Public, Public, false);
        AddProperty(typeof(string), nameof(ModularBaseRole.NormalizedName), Public, Public, false);
    }

    protected void InitInterfaces()
    {
        AddInterface(typeof(IModularBaseRole));
        AddInterface(typeof(IModularBaseRole<int>));
    }

    protected void InitConstructors()
    {
        AddConstructor(Public, new Type[] { });
    }

    public ModularBaseRoleSchema()
    {
        InitFields();
        InitProperties();
        InitInterfaces();
        InitConstructors();
    }
}