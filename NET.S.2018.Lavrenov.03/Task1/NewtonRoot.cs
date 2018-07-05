using System;

namespace Task1
{
    /// <summary>
    /// Static class for finding n-degree root from real number
    /// </summary>
    public static class NewtonRoot
    {
        /// <summary>
        /// Newton method for finding n-degree root.
        /// Return number if degree is 1.
        /// <exception cref="ArgumentException">degree less or equals 0 </exception>
        /// <exception cref="ArgumentException">accuracy less or euqals 0</exception>
        /// <exception cref="ArgumentException">accuracy greater or equels 1</exception>
        /// <exception cref="ArgumentException">root of even degree from a negative number</exception>
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="degree">degree</param>
        /// <param name="accuracy">precision</param>
        /// <returns>The root of the n-power of a number with a given accuracy</returns>
        public static double FindNthRoot(double number, int degree, double accuracy)
        {
            if (degree <= 0)
            {
                throw new ArgumentException($"int degree ={nameof(degree)} <=0");
            }

            if (accuracy <= 0 || accuracy >= 1)
            {
                throw new ArgumentException($"int accuracy={nameof(accuracy)} couldn't be <=0 or >=1");
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException($"It is impossible to find a root of even degree from a negative number");
            }

            if (degree == 1)
            {
                return number;
            }

            double currentApproximation = accuracy + number / degree;
            double followingApproximation = ((degree - 1) * currentApproximation +
                                             number / Math.Pow(currentApproximation, degree - 1)) / degree;

            while (Math.Abs(followingApproximation - currentApproximation) >= accuracy + accuracy / degree)
            {
                currentApproximation = followingApproximation;
                followingApproximation = ((degree - 1) * currentApproximation +
                                          number / Math.Pow(currentApproximation, degree - 1)) / degree;
            }

            return followingApproximation;
        }
    }
}
