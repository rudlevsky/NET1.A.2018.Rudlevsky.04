using System;
using System.Text;
using DoubleConverter;

namespace WordGeneration
{
    /// <summary>
    /// Creates string representation of the number.
    /// </summary>
    /// <param name="number">Numeric representation of the number.</param>
    /// <returns>Number in string representation.</returns>
    public delegate string Transformer(double number);

    /// <summary>
    /// Class contains methods for generating words.
    /// </summary>
    public static class WordGenerator
    {
        /// <summary>
        /// Check array according rules and find string words.
        /// </summary>
        /// <param name="numbers">User's array of numbers.</param>
        /// <returns>Return string representation of user's numbers.</returns>
        public static string[] TransformToWords(double[] numbers)
        {
            CheckRules(numbers);

            string[] allResults = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                allResults[i] = GetUsualNum(numbers[i]);
            }

            return allResults;
        }

        /// <summary>
        /// Check array according rules and find string words.
        /// </summary>
        /// <param name="numbers">User's array of numbers.</param>
        /// <returns>Return string representation of user's numbers in IEEE format.</returns>
        public static string[] TransformToIEEEFormat(double[] numbers)
        {
            CheckRules(numbers);

            string[] allResults = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                allResults[i] = GetIEEENum(numbers[i]);
            }

            return allResults;
        }

        /// <summary>
        /// Check array according rules and find string words according delegate method.
        /// </summary>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="transformer">Delegate which contains method for getting string representation of the word.</param>
        /// <returns>Return string representation of user's numbers.</returns>
        public static string[] TransformToWords(double[] numbers, Transformer transformer)
        {
            CheckRules(numbers);

            return CountWords(numbers, transformer);
        }

        /// <summary>
        /// Creates string representation of the number.
        /// </summary>
        /// <param name="number">Numeric representation of the number.</param>
        /// <returns>Number in string representation.</returns>
        public static string GetUsualNum(double number)
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

        /// <summary>
        /// Creates string representation of the number in IEEE format.
        /// </summary>
        /// <param name="number">Numeric representation of the number.</param>
        /// <returns>Number in string representation in IEEE format.</returns>
        public static string GetIEEENum(double number) =>
            Converter.ConvertToBinary(number);

        private static string[] CountWords(double[] numbers, Transformer transformer)
        {
            string[] allResults = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                allResults[i] = transformer(numbers[i]);
            }

            return allResults;
        }

        private static void CheckRules(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers) + " can't be equal to null");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException(nameof(numbers) + " length can't be equal to 0");
            }
        }
    }
}
