using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution
{
    public static class Calculator2
    {
        public static double CalculateAverange(IAvgMethod method, params double[] value)
        {
            return method.GetAvg(value);
        }

    }
}
