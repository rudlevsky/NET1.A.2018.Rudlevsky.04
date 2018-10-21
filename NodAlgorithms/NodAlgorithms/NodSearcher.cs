using System;
using System.Diagnostics;

namespace NodAlgorithms
{
    /// <summary>
    /// Class contains methods for getting nod.
    /// </summary>
    public static class NodSearcher
    {
        /// <summary>
        /// Return nod of numbers from the array.
        /// </summary>
        /// <param name="array">Array of numbers.</param>
        /// <returns>Nod of numbers from the array.</returns>
        public static int GetNodE(params int[] array)
        {
            CheckRules(array);

            int temp = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                temp = EvklAlg(temp, array[i]);
            }

            return temp;
        }

        /// <summary>
        /// Return nod of numbers from the array.
        /// </summary>
        /// <param name="time">Time lasted during the algorithm's implementation.</param>
        /// <param name="array">Array of numbers.</param>
        /// <returns>Nod of numbers from the array.</returns>
        public static int GetNodE(out long time, params int[] array)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int nod = GetNodE(array);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return nod;
        }

        /// <summary>
        /// Return nod of numbers from the array.
        /// </summary>
        /// <param name="array">Array of numbers.</param>
        /// <returns>Nod of numbers from the array.</returns>
        public static int GetNodS(params int[] array)
        {
            CheckRules(array);

            int temp = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                temp = SteinAlg(temp, array[i]);
            }

            return temp;
        }

        /// <summary>
        /// Return nod of numbers from the array.
        /// </summary>
        /// <param name="time">Time lasted during the algorithm's implementation.</param>
        /// <param name="array">Array of numbers.</param>
        /// <returns>Nod of numbers from the array.</returns>
        public static int GetNodS(ref long time, params int[] array)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int nod = GetNodS(array);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return nod;
        }

        private static int EvklAlg(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);

            return EvklAlg(b, a % b);
        }

        private static int SteinAlg(int a, int b)
        {
            if (a == 0)
                return b;

            if (b == 0)
                return a;

            if (a == b)
                return a;

            if (a == 1 || b == 1)
                return 1;

            if ((a & 1) == 0)
                return ((b & 1) == 0)
                    ? SteinAlg(a >> 1, b >> 1) << 1
                    : SteinAlg(a >> 1, b);
            else
                return ((b & 1) == 0)
                    ? SteinAlg(a, b >> 1)
                    : SteinAlg(b, a > b ? a - b : b - a);
        }

        /// <summary>
        /// Check array according special rules.
        /// </summary>
        /// <param name="array">Array for checking.</param>
        /// <exception cref="ArgumentException">Throws when array argument is empty.</exception>
        /// <exception cref="ArgumentNullException">Throws when array equals to null.</exception>
        private static void CheckRules(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + " can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + " can't be equal to 0");
            }
        }
    }
}
