using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Double Extension class
    /// </summary>
    public static class DoubleExtension
    {
        #region Const

        private const int BitsInByte = 8;

        #endregion

        #region public API

        /// <summary>
        /// The method makes it possible to obtain a string representation of a real value
        /// in the format IEEE 754
        /// </summary>
        /// <param name="value">double value</param>
        /// <returns>string in IEEE 754</returns>
        public static string ToIeee754Double(this double value)
        {

            var tempStruct = new DoubleToLongStruct(value);
            long longValue = (long)tempStruct;

            return longValue.LongToBitString();
        }

        #endregion

        #region Private API

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public DoubleToLongStruct(double number) : this()
            {
                double64bits = number;
            }

            public static explicit operator long(DoubleToLongStruct doubleStruct)
            {
                return doubleStruct.long64bits;
            }
        }

        private static string LongToBitString(this long value)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < BitsInByte * 8; i++)
            {
                sb.Append(value & 1);
                value >>= 1;
            }

            return sb.Reverse().ToString();
        }

        public static StringBuilder Reverse(this StringBuilder sb)
        {
            StringBuilder newStringBuilder = new StringBuilder(sb.Length);

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                newStringBuilder.Append(sb[i]);
            }

            return newStringBuilder;
        }

        #endregion
    }
}
