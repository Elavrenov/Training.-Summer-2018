using System;

namespace Task1
{
    /// <summary>
    /// Static class for finding n-degree root from real number
    /// </summary>
    public static class NewtonRoot
    {
        /// <summary>
        /// Newton method for finding n-degree root
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="degree">degree</param>
        /// <param name="accuracy">precision</param>
        /// <returns></returns>
        public static double FindNthRoot(double number, int degree, double accuracy)
        {
            if (degree <= 0)
            {
                throw new ArgumentException(nameof(degree));
            }

            if (accuracy < 0 || accuracy > 1)
            {
                throw new ArgumentException(nameof(accuracy));
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException(nameof(number));
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
