using WordGeneration.Interfaces;
using DoubleConverter;

namespace WordGeneration.Tests.Models
{
    /// <summary>
    /// Class perform converting to IEEE format.
    /// </summary>
    public class IEEEFormatter : ITransformer<double, string>
    {
        /// <summary>
        /// Creates string representation of the number in IEEE format.
        /// </summary>
        /// <param name="number">Numeric representation of the number.</param>
        /// <returns>Number in string representation in IEEE format.</returns>
        public string Perform(double number) => Converter.ConvertToBinary(number);
    }
}
