using System;

namespace Task1
{
    /// <summary>
    /// Class for working with bits
    /// </summary>
    public class BitChanger
    {
        /// <summary>
        /// The method implements the algorithm for inserting bits from j to i bits of one number into another
        /// so that the bits of the second number occupy positions from bit j over bit i
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <param name="startIndex">inex for starting</param>
        /// <param name="endIndex">index for ending</param>
        /// <returns></returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int startIndex, int endIndex)
        {
            const byte maxbit = 31;

            if (startIndex < 0 || startIndex > maxbit)
            {
                throw new ArgumentOutOfRangeException(nameof(maxbit));
            }

            if (endIndex < 0 || endIndex > maxbit)
            {
                throw new ArgumentOutOfRangeException(nameof(maxbit));
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentException(nameof(startIndex));
            }

            int range = endIndex - startIndex ;

            int firstContainer = int.MaxValue >> maxbit - (range + 1);
            firstContainer <<= startIndex;
            firstNumber &= ~firstContainer;

            int secondContainer = int.MaxValue >> (maxbit - (range + 1));
            secondContainer &= secondNumber;
            secondContainer <<= startIndex;

            secondContainer &= firstContainer;
            return firstNumber | secondContainer;

        }
    }
}
