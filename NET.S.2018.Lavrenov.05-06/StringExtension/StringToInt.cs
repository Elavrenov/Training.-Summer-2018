using System;
using System.Collections.Generic;

namespace StringExtension
{
    /// <summary>
    /// String extension class
    /// </summary>
    public static class StringToInt
    {
        #region Public API
        /// <summary>
        /// Method of extending the output from a string representation of an integer positive
        /// four-byte number written in the p-ary number system, its integer value
        /// </summary>
        /// <param name="value">string</param>
        /// <param name="notation">p-ary number system</param>
        /// <returns>integer value</returns>
        /// <exception cref="ArgumentException">notation could be in segment [2,16]</exception>
        /// <exception cref="ArgumentException">notation must match its string representation</exception>
        /// <exception cref="OverflowException">value must be in true format</exception>
        /// <exception cref="OverflowException">for notation equals 2 value can't be greater than 32</exception>
        public static int ConvertToInt32(this string value, int notation)
        {
            if (notation < 2 || notation > 16)
            {
                throw new ArgumentException($"{nameof(notation)} must be in segment [2,16]");
            }

            int[] valueArray = value.StringToArray(notation);
            int answer = 0;
            int n = 1;

            for (int i = valueArray.Length - 1; i >= 0; i--)
            {
                checked
                {
                    answer += valueArray[i] * n;
                    n *= notation;
                }

            }

            return answer;
        }

        #endregion

        #region Private API

        private static int[] StringToArray(this string value, int notation)
        {
            List<int> intList = new List<int>();

            for (int i = 0; i < value.Length; i++)
            {
                if (Int32.TryParse(value[i].ToString(), out int result))
                {
                    intList.Add(result);
                }
                else
                {
                    if (notation != 16)
                    {
                        throw new ArgumentException($"{nameof(value)} wrong format");
                    }

                    switch (value[i].ToString().ToUpper())
                    {
                        case "A":
                            intList.Add(10);
                            break;
                        case "B":
                            intList.Add(11);
                            break;
                        case "C":
                            intList.Add(12);
                            break;
                        case "D":
                            intList.Add(13);
                            break;
                        case "E":
                            intList.Add(14);
                            break;
                        case "F":
                            intList.Add(15);
                            break;
                        default: throw new ArgumentException($"{nameof(value)} is not exist");
                    }
                }
            }

            return intList.ToArray();
        }

        #endregion
    }
}
