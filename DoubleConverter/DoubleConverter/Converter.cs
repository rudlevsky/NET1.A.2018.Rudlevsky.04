using System.Runtime.InteropServices;
using System.Text;

namespace DoubleConverter
{
    /// <summary>
    /// Class extends type System.Double.
    /// </summary>
    public static class Converter
    {
        private const int BitsLongCount = 64;

        /// <summary>
        /// Extend functionality of type System.Double.
        /// </summary>
        /// <param name="number">Number which will be represented in IEEE format.</param>
        /// <returns>String representation in IEEE format.</returns>
        public static string ConvertToBinary(this double number) =>
            new DoubleStruct(number).ConvertLong().ConvertToIEEE();

        private static string ConvertToIEEE(this long bits)
        {
            var result = new StringBuilder(); // Set char[] and pass it to this constructor
            for (int i = 0; i < BitsLongCount; i++)
            {
                if ((bits & 1) == 1)
                {
                    result.Insert(0, "1");
                }
                else
                {
                    result.Insert(0, "0");
                }

                bits >>= 1;
            }

            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleStruct
        {
            [FieldOffset(0)]
            private double dbBits;

            [FieldOffset(0)]
            private long lgBits;

            public DoubleStruct(double variable) : this()
            {
                this.dbBits = variable;
            }

            public long ConvertLong() => this.lgBits;
        }
    }
}
