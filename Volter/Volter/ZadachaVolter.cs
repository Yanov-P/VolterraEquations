using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volter
{
    class ZadachaVolter
    {
        public double h = 0.25;
        public double a = 0;
        public double b = 1;
        public double[] curRes = {};
        private double length = 0;

        private double K(int i, int j)
        {
            return Math.Exp(-x(i) + x(j));
        }
        private double f(int i)
        {
            return Math.Exp(-x(i));
        }
        public double x(int i)
        {
            return a + i * h;
        }

        public double OtnositPogr()
        {
            double res = 0;
            double resZn = 0;
            for (int i = 0; i < curRes.Length - 1; i++)
            {
                res = Math.Max(Math.Abs(curRes[i] - curRes[i + 1]), res);
                resZn = Math.Max(Math.Abs(curRes[i]), resZn);
            }

            return res / resZn;
        }
        private double A(int i)
        {
            if (i == 0 || i == length - 1) return h / 2;
            else return h;
        }
        
        public void SolveKvadr()
        {
            int length = (int)((b - a) / h);
            double[] res = new double[length];
            for (int i = 0; i < length; i++)
            {
                double sum = 0;
                for (int j = 0; j < i-1; j++)
			    {
			        sum += K(i,j) * res[j] * A(j);
			    }
                res[i] = 1 / (1 - K(i, i) * A(i)) * (f(i) + sum);
            }
            curRes = res;
        }
    }
}
