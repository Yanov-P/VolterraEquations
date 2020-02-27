using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volter
{
    static class MyFunctions
    {
        public static double X(double x)
        {
            return x;
        }

        public static double SquaredX(double x)
        {
            return x*x;
        }

        public static double ExpXMinusX(double x)
        {
            return Math.Exp(x) - x;
        }

        public static double X_ExpXSMinus1_(double x, double s)
        {
            return x * (Math.Exp(x * s) - 1);
        }
    }
}
