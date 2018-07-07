using System;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Double Extension class
    /// </summary>
    public static class DoubleExtension
    {
        #region public API
        /// <summary>
        /// The method makes it possible to obtain a string representation of a real number
        /// in the format IEEE 754
        /// </summary>
        /// <param name="number">double number</param>
        /// <returns>string in IEEE 754</returns>
        public static string ToIeee754Double(this double number)
        {
            long intPart = Math.Abs((long)(number - number % 1));
            double fracPart = Math.Abs(number % 1);

            StringBuilder intPartStr = WholeLongPartToBinary(intPart);
            StringBuilder fracPartStr = FractionalDoublePartToBinary(fracPart);

            StringBuilder mantissa = CreateMantissa(intPartStr, fracPartStr);
            StringBuilder exponent = CreateExponent(intPartStr, fracPartStr);
            StringBuilder answer = new StringBuilder();

            return answer.Append(number > 0 ? 0 : 1).Append(exponent).Append(mantissa).ToString();
        }

        #endregion

        #region Private API

        private static StringBuilder CreateExponent(StringBuilder intPart, StringBuilder fracPart)
        {
            StringBuilder exponent = new StringBuilder();

            if (FindIndexOfOne(intPart) != -1)
            {
                return exponent.Append(WholeLongPartToBinary(1023 + intPart.Length - FindIndexOfOne(intPart) - 1));
            }

            return exponent.Append(WholeLongPartToBinary(1023 - (FindIndexOfOne(fracPart) + 1)));
        }
        private static StringBuilder CreateMantissa(StringBuilder intPart, StringBuilder fracPart)
        {
            StringBuilder mantissa = new StringBuilder();

            if (FindIndexOfOne(fracPart) != -1)
            {
                for (int i = FindIndexOfOne(intPart) + 1; i < intPart.Length; i++)
                {
                    mantissa.Append(intPart[i]);
                }

                for (int i = 0; i <= 52 - (intPart.Length + FindIndexOfOne(intPart)); i++)
                {
                    mantissa.Append(fracPart[i]);
                }
            }
            else
            {
                for (int i = FindIndexOfOne(fracPart) + 1; i < fracPart.Length; i++)
                {
                    mantissa.Append(fracPart[i]);
                }
            }

            return mantissa;
        }

        private static int FindIndexOfOne(StringBuilder someString)
        {
            for (int i = 0; i < someString.Length; i++)
            {
                if (someString[i] == '1')
                {
                    return i;
                }
            }

            return -1;
        }
        private static StringBuilder WholeLongPartToBinary(long wholePart)
        {
            StringBuilder bitString = new StringBuilder();
            long temp = 0;

            while (wholePart != 0)
            {
                temp = wholePart % 2;
                bitString.Append(temp);
                wholePart /= 2;
            }

            return bitString.Reverse();
        }

        private static StringBuilder Reverse(this StringBuilder sb)
        {
            StringBuilder newString = new StringBuilder(sb.Length);
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                newString.Append(sb[i]);
            }

            return newString;
        }

        private static StringBuilder FractionalDoublePartToBinary(double fractionPart)
        {
            StringBuilder bitString = new StringBuilder();

            for (int i = 0; i < 52; i++)
            {
                bitString.Append((int)(fractionPart * 2) / 1);
                fractionPart = (fractionPart * 2) % 1;
            }

            return bitString;
        }

        #endregion
    }
}
