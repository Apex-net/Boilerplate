namespace Convenient.System.Data.Entity.Seeding
{
    public interface ISeedDataFactory<out T>
    {
        T[] All();
    }
}
