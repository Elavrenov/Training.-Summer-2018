using System;
using System.Collections.Generic;

namespace Task6
{
    /// <summary>
    /// Extension class to bring the array to a specific type
    /// </summary>
    public static class DigitExtenshion
    {
        #region Public API

        /// <summary>
        /// Filter the array based on the parameter digit
        /// </summary>
        /// <param name="digit">parameter</param>
        /// <param name="array">array for filtring</param>
        /// <returns></returns>
        public static int[] FilterDigit(int digit, params int[] array)
        {
            if (array==null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (array.Length==1)
            {
                throw new ArgumentException(nameof(array));
            }

            List<int> tempList = new List<int>();

            foreach (var item in array)
            {
                if (IsValidNumber(item,digit))
                {
                    tempList.Add(item);
                }

            }

            return tempList.ToArray();
        }

        #endregion

        #region Private API

        /// <summary>
        /// The method returns true if the number contains a digit
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="digit">condition digit</param>
        /// <returns></returns>
        private static bool IsValidNumber(int number, int digit)
        {
            while (number !=0)
            {
                int temp = number % 10;
                if (temp==digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        #endregion
        
    }
}
