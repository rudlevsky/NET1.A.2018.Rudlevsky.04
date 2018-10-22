using System;
using System.Text;
using DoubleConverter;

namespace WordGeneration
{
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

            return TransformWords(numbers, false);
        }

        public static string[] TransformToIEEEFormat(double[] numbers)
        {
            CheckRules(numbers);

            return TransformWords(numbers, true);
        }

        private static string GetUsualNum(double number)
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

        private static string GetIEEENum(double number) =>
            Converter.ConvertToBinary(number);
        
        private static string[] TransformWords(double[] numbers, bool IsIEEE)
        {
            string[] allResults = new string[numbers.Length];
            int count = 0;

            for (int k = 0; k < numbers.Length; k++)
            {
                if (IsIEEE)
                {
                    allResults[count] = GetIEEENum(numbers[k]);
                }
                else
                {
                    allResults[count] = GetUsualNum(numbers[k]);
                }

                count++;
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
