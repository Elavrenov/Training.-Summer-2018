using System;
using System.Collections.Generic;

namespace Task6
{
    /// <summary>
    /// Extension class to bring the array to a specific type
    /// </summary>
    public static class DigitExtenshion
    {
        /// <summary>
        /// Filter the array based on the parameter digit
        /// </summary>
        /// <param name="array">changing array</param>
        /// <param name="digit">condition digit</param>
        public static void FilterDigit(ref int[] array,int digit)
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

            array = tempList.ToArray();
        }
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
    }
}
