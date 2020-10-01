namespace Jlw.Extensions.Identity.Stores
{
    public interface IModularBaseRole : IModularBaseRole<int> { }

    public interface IModularBaseRole<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; set; }
    }
}