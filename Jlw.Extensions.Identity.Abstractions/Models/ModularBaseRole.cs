
namespace Jlw.Extensions.Identity
{
    public class ModularBaseRole : ModularBaseRole<int>, IModularBaseRole { }


    public class ModularBaseRole<TKey> : IModularBaseRole<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
}
