using System.Text;
using WordGeneration.Interfaces;

namespace WordGeneration.Tests.Models
{
    /// <summary>
    /// Class perform converting to word format.
    /// </summary>
    public class WordFormatter : ITransformer<double, string>
    {
        /// <summary>
        /// Creates string representation of the number.
        /// </summary>
        /// <param name="number">Numeric representation of the number.</param>
        /// <returns>Number in string representation.</returns>
        public string Perform(double number)
        {
            string[] arrayWord = new string[] { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ", "minus ", "point " };
            var arrayResult = new StringBuilder();

            string str = number.ToString();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-')
                {
                    arrayResult.Append(arrayWord[arrayWord.Length - 2]);
                    continue;
                }

                if (str[i] == '.')
                {
                    arrayResult.Append(arrayWord[arrayWord.Length - 1]);
                    continue;
                }

                for (int j = 0; j < arrayWord.Length; j++)
                {
                    if (int.TryParse(str[i].ToString(), out int result))
                    {
                        if (j == result)
                        {
                            arrayResult.Append(arrayWord[j]);
                        }
                    }
                }
            }

            arrayResult.Remove(arrayResult.Length - 1, 1);

            return arrayResult.ToString();
        }
    }
}
