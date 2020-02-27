using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volter
{
    static class Quadratures
    {
        public static double Trapeze(int i, Net net)
        {
            if (i == 0 || i == net.X.Length - 1)
            {
                return net.NetStep[i] / 2;
            }
            return net.NetStep[i];
        }

        public static double Simpson(int i, Net net)
        {
            if (i == 0 || i == net.X.Length - 1)
            {
                return net.NetStep[i] / 3;
            }
            if (i % 2 == 1)
            {
                return net.NetStep[i] * 4 / 3;
            }
            return net.NetStep[i] * 2 / 3;
        }

        public static double LeftRectangle(int i, Net net)
        {
            return net.NetStep[i];
        }
    }
}
