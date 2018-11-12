
namespace WordGeneration.Interfaces
{
    public interface IPredicate<in TSource>
    {
        bool IsCorrect(TSource source);
    }
}
