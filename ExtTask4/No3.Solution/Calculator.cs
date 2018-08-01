using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution
{
    public static class Calculator
    {
        public static double CalculateAverange(Func<double[],double> func, params double[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (values.Length == 1)
            {
                return values[0];
            }

            return func(values);
        }
    }
}
