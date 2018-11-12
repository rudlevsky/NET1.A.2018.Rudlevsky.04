
namespace WordGeneration.Interfaces
{
    /// <summary>
    /// Contains method for checking rules.
    /// </summary>
    /// <typeparam name="TSource">Type of source.</typeparam>
    public interface IPredicate<in TSource>
    {
        /// <summary>
        /// Method checks rules.
        /// </summary>
        /// <param name="source">Passed source.</param>
        /// <returns>Boolean result of checking.</returns>
        bool IsCorrect(TSource source);
    }
}
