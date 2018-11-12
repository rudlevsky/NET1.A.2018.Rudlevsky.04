using System;
using System.Collections.Generic;
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
        public static TResult[] TransformToFormat<TSource, TResult>(this TSource[] numbers, ITransformer<TSource, TResult> transformer)
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
        public static TResult[] TransformToFormat<TSource, TResult>(this TSource[] numbers, Func<TSource, TResult> transformer)
        {
            CheckRules(numbers);

            return ChangeWords(numbers, transformer);
        }

        private static TResult[] ChangeWords<TSource, TResult>(TSource[] numbers, Func<TSource, TResult> transformer)
        {
            var allResults = new TResult[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                allResults[i] = transformer(numbers[i]);
            }

            return allResults;
        }

        public static TSource[] Filter<TSource>(this TSource[] numbers, IPredicate<TSource> predicate)
        {
            CheckRules(numbers);

            return ToFilter(numbers, predicate.IsCorrect);
        }

        public static TSource[] Filter<TSource>(this TSource[] numbers, Predicate<TSource> predicate)
        {
            CheckRules(numbers);

            return ToFilter(numbers, predicate);
        }

        private static TSource[] ToFilter<TSource>(this TSource[] numbers, Predicate<TSource> predicate)
        {
            var arrayResult = new List<TSource>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if(predicate(numbers[i]))
                {
                    arrayResult.Add(numbers[i]);
                }
            }

            return arrayResult.ToArray();
        }

        private static void CheckRules<TSource>(TSource[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException($"{nameof(numbers)} can't be equal to null");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException($"{nameof(numbers)} length can't be equal to 0");
            }
        }
    }
}
