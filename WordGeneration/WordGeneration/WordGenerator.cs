using System;
using WordGeneration.Interfaces;

namespace WordGeneration
{
    /// <summary>
    /// Class contains methods for generating words.
    /// </summary>
    public static class WordGenerator
    {
        /// <summary>
        /// Check array according rules and find string words according delegate method.
        /// </summary>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="transformer">Delegate which contains method for getting string representation of the word.</param>
        /// <returns>Return string representation of user's numbers.</returns>
        public static string[] TransformToFormat(double[] numbers, ITransformer transformer)
        {
            CheckRules(numbers);

            return ChangeWords(numbers, transformer.Perform);
        }

        /// <summary>
        /// Check array according rules and find string words according delegate method.
        /// </summary>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="transformer">Delegate which contains method for getting string representation of the word.</param>
        /// <returns>Return string representation of user's numbers.</returns>
        public static string[] TransformToFormat(double[] numbers, Func<double, string> transformer)
        {
            CheckRules(numbers);

            return ChangeWords(numbers, transformer);
        }

        private static string[] ChangeWords(double[] numbers, Func<double, string> transformer)
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
