using System;
using System.Diagnostics;

namespace NodAlgorithms
{
    /// <summary>
    /// Finds a nod of two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>Nod of two numbers.</returns>
    public delegate int Transformer(int a, int b);

    /// <summary>
    /// Class contains methods for getting nod.
    /// </summary>
    public static class NodSearcher
    {
        /// <summary>
        /// Method calculates nod from the array of numbers.
        /// </summary>
        /// <param name="time">Time of calculating.</param>
        /// <param name="array">Array of numbers for calculations.</param>
        /// <returns>Nod of numbers from the array.</returns>
        public static int GetNod(out long time, Transformer transformer, params int[] array)
        {
            CheckRules(array);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int temp = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                temp = transformer(temp, array[i]);
            }

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return temp;
        }

        /// <summary>
        /// Method calculates nod of two numbers.
        /// </summary>
        /// <param name="time">Time of calculating.</param>
        /// <param name="num1">First number.</param>
        /// <param name="num2">Second number.</param>
        /// <returns>Nod of numbers.</returns>
        public static int GetNod(out long time, int num1, int num2, Transformer transformer)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int temp = transformer(num1, num2);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return temp;
        }

        /// <summary>
        /// Method calculates nod of three numbers.
        /// </summary>
        /// <param name="time">Time of calculating.</param>
        /// <param name="num1">First number.</param>
        /// <param name="num2">Second number.</param>
        /// <param name="num3">Third number.</param>
        /// <returns>Nod of numbers.</returns>
        public static int GetNod(out long time, int num1, int num2, int num3, Transformer transformer)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int temp = transformer(transformer(num1, num2), num3);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return temp;
        }

        /// <summary>
        /// Method calculates nod of four numbers.
        /// </summary>
        /// <param name="time">Time of calculating.</param>
        /// <param name="num1">First number.</param>
        /// <param name="num2">Second number.</param>
        /// <param name="num3">Third number.</param>
        /// <param name="num4">Fourth number.</param>
        /// <returns>Nod of numbers.</returns>
        public static int GetNod(out long time, int num1, int num2, int num3, int num4, Transformer transformer)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int temp = transformer(transformer(transformer(num1, num2), num3), num4);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return temp;
        }

        /// <summary>
        /// Method calculates nod.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Returns nod.</returns>
        public static int EvklAlg(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);

            return EvklAlg(b, a % b);
        }

        /// <summary>
        /// Method calculates nod.
        /// </summary>
        /// <param name="a">First argument.</param>
        /// <param name="b">Second argument.</param>
        /// <returns>Nod of two arguments.</returns>
        public static int SteinAlg(int a, int b)
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
