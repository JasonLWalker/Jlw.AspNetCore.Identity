namespace Jlw.Extensions.Identity
{
    public interface IModularBaseRole : IModularBaseRole<int> { }

    public interface IModularBaseRole<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; set; }
    }
}