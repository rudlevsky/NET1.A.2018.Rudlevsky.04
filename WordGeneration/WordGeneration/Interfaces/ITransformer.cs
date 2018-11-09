
namespace WordGeneration.Interfaces
{
    /// <summary>
    /// Interface contains method for performing convertions.
    /// </summary>
    public interface ITransformer
    {
        /// <summary>
        /// Creates string representation of the number.
        /// </summary>
        /// <param name="number">Numeric representation of the number.</param>
        /// <returns>Number in string representation.</returns>
        string Perform(double number);
    }
}
