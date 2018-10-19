using System;
using System.Text;

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
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers) + " can't be equal to null");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException(nameof(numbers) + " length can't be equal to 0");
            }

            return TransformWords(numbers);
        }

        private static string[] TransformWords(double[] numbers)
        {
            string[] arrayWord = new string[] { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine " };
            var strNumber = new StringBuilder();
            var arrayResult = new StringBuilder();
            string[] allResults = new string[numbers.Length];
            int count = 0;

            for (int k = 0; k < numbers.Length; k++)
            {
                strNumber.Append(numbers[k].ToString());

                if (strNumber[0] == '-')
                {
                    arrayResult.Append("minus ");
                    strNumber.Remove(0, 1);
                }

                for (int i = 0; i < strNumber.Length; i++)
                {
                    if (strNumber[i] == '.')
                    {
                        arrayResult.Append("point ");
                    }
                    else
                    {
                        for (int j = 0; j < arrayWord.Length; j++)
                        {
                            if (j == int.Parse(strNumber[i].ToString()))
                            {
                                arrayResult.Append(arrayWord[j]);
                            }
                        }
                    }
                }

                arrayResult.Remove(arrayResult.Length - 1, 1);
                allResults[count] = arrayResult.ToString();
                count++;
                strNumber.Clear();
                arrayResult.Clear();
            }

            return allResults;
        }
    }
}
