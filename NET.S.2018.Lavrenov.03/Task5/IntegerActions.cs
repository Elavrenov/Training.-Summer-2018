namespace Task5
{
    /// <summary>
    /// Сlass extends the possibility of working with integers
    /// </summary>
    public static class IntegerActions
    {
        #region Public API

        /// <summary>
        /// The method takes a positive integer and returns the nearest largest integer consisting 
        /// of the digits of the original number, and null (or -1), if such a number does not exist.
        /// </summary>
        /// <param name="number">original number</param>
        /// <returns>
        /// nearest largest integer consisting 
        /// of the digits of the original number
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number == FindCloseBiggerNumber(number, out int endIndex) || number < 0)
            {
                return -1;
            }

            number = FindCloseBiggerNumber(number, out endIndex);
            int[] numberArray = NumberToAray(number);

            for (int i = numberArray.Length - 1; i > endIndex + 1; i--)
            {
                if (numberArray[i] < numberArray[i - 1])
                {
                    Swap(ref numberArray[i], ref numberArray[--i]);
                    i = numberArray.Length;
                }
            }

            return ArrayToNumber(numberArray);
        }

        #endregion


        #region Private API

        /// <summary>
        /// The method for swapping two element
        /// </summary>
        /// <param name="firstElement">first element</param>
        /// <param name="secondElement">second element</param>
        private static void Swap(ref int firstElement, ref int secondElement)
        {
            int temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        /// <summary>
        /// The method takes 2 parameters, the original number and some index,
        /// returns a number greater than the given and the index from which the number is greater
        /// </summary>
        /// <param name="number">original number</param>
        /// <param name="stopIndex">index</param>
        /// <returns>
        /// number greater than the given and the index from which the number is greater
        /// </returns>
        private static int FindCloseBiggerNumber(int number, out int stopIndex)
        {
            int[] biggerNumber = NumberToAray(number);
            for (stopIndex = biggerNumber.Length - 1; stopIndex > 0; stopIndex--)
            {
                if (biggerNumber[stopIndex] > biggerNumber[stopIndex - 1])
                {
                    Swap(ref biggerNumber[stopIndex], ref biggerNumber[--stopIndex]);
                    return ArrayToNumber(biggerNumber);
                }
            }

            return ArrayToNumber(biggerNumber);
        }

        /// <summary>
        /// The method takes an integer array and returns a number corresponding to it
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>returns a number corresponding to given array</returns>
        private static int ArrayToNumber(int[] array)
        {
            int number = 0;
            int factor = 1;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                number += array[i] * factor;
                factor *= 10;
            }

            return number;
        }

        /// <summary>
        /// The method takes an integer and returns an array corresponding to it
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>returns a array corresponding to given number</returns>
        private static int[] NumberToAray(int number)
        {
            int i = number.ToString().Length - 1;
            int[] numberArray = new int[number.ToString().Length];

            while (number != 0)
            {
                int temp = number % 10;
                numberArray[i--] = temp;
                number /= 10;
            }

            return numberArray;
        }

        #endregion
    }
}
