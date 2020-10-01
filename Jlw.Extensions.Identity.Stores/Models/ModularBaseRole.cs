namespace Jlw.Extensions.Identity.Stores
{
    public class ModularBaseRole : ModularBaseRole<int> { }


    public class ModularBaseRole<TKey> : IModularBaseRole<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
}
