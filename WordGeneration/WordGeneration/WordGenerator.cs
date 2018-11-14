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
        /// <typeparam name="TSource">Type of source.</typeparam>
        /// <typeparam name="TResult">Type of returned result.</typeparam>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="transformer">Interface which contains method for getting string representation of the word.</param>
        /// <returns>Return string representation of user's numbers.</returns>
        public static IEnumerable<TResult> TransformToFormat<TSource, TResult>(this IEnumerable<TSource> numbers, ITransformer<TSource, TResult> transformer)
        {
            return ChangeWords(numbers, transformer.Perform);
        }

        /// <summary>
        /// Check array according rules and find string words according delegate method.
        /// </summary>
        /// <typeparam name="TSource">Type of source.</typeparam>
        /// <typeparam name="TResult">Type of returned result.</typeparam>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="transformer">Delegate which contains method for getting string representation of the word.</param>
        /// <returns>Return string representation of user's numbers.</returns>
        public static IEnumerable<TResult> TransformToFormat<TSource, TResult>(this IEnumerable<TSource> numbers, Func<TSource, TResult> transformer)
        {
            return ChangeWords(numbers, transformer);
        }
    
        /// <summary>
        /// Filters passed array according passed logic.
        /// </summary>
        /// <typeparam name="TSource">Type of passed array.</typeparam>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="predicate">Interface which contains method for getting string representation of the word.</param>
        /// <returns>Filtered array.</returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> numbers, IPredicate<TSource> predicate)
        {
            return ToFilter(numbers, predicate.IsCorrect);
        }

        /// <summary>
        /// Filters passed array according passed logic.
        /// </summary>
        /// <typeparam name="TSource">Type of passed array.</typeparam>
        /// <param name="numbers">User's array of numbers.</param>
        /// <param name="predicate">Delegate which contains method for getting string representation of the word.</param>
        /// <returns>Filtered array.</returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> numbers, Predicate<TSource> predicate)
        {
            return ToFilter(numbers, predicate);
        }

        private static IEnumerable<TResult> ChangeWords<TSource, TResult>(IEnumerable<TSource> numbers, Func<TSource, TResult> transformer)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException($"{nameof(numbers)} can't be equal to null");
            }
            return Transformation();

            IEnumerable<TResult> Transformation()
            {
                var arrayResult = new List<TResult>();

                foreach (var item in numbers)
                {
                    yield return transformer(item);
                }
            }
        }

        private static IEnumerable<TSource> ToFilter<TSource>(this IEnumerable<TSource> numbers, Predicate<TSource> predicate)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException($"{nameof(numbers)} can't be equal to null");
            }

            return Transformation();

            IEnumerable<TSource> Transformation()
            {
                var arrayResult = new List<TSource>();

                foreach (var item in numbers)
                {
                    if (predicate(item))
                    {
                        arrayResult.Add(item);
                    }
                }

                return arrayResult;
            }
        }
    }
}
