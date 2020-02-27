using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volter
{
    class Solver
    {
        private Net _net;
        private Problem _problem;
        public Func<int, Net, double> Quadrature { get; set; }
        public Func<double, double> YFunct {get; set;}
        public double[] Y { get { return _net.Y; } set { _net.Y = value; } }
        public double[] X { get { return _net.X; } }
        

        private double A(int i)
        {
            return Quadrature(i, _net);
        }
        
        public Solver(Net net, Problem problem)
        {
            YFunct = MyFunctions.X;
            _net = net;
            _problem = problem;
            Quadrature = Quadratures.Trapeze;
        }

        public Solver(Net net, Problem problem, Func<int, Net, double> A) 
            : this(net, problem)
        {
            this.Quadrature = A;
        }

        public double RelativeError(double[] Y)
        {
            double res = 0;
            double resDen = 0;
            for (int i = 0; i < Y.Length - 1; i++)
            {
                res = Math.Max(Math.Abs(Y[i] - Y[i + 1]), res);
                resDen = Math.Max(Math.Abs(Y[i]), resDen);
            }

            return res / resDen;
        }
        public double[] QuadratureSolve()
        {
            int length = X.Length;
            Y = new double[length];
            for (int i = 0; i < length; i++)
            {
                double sum = 0;
                for (int j = 0; j < i ; j++)
                {
                    sum += _problem.K(X[i], X[j]) * Y[j] * A(j);
                }
                Y[i] = 1 / (1 - _problem.K(i, i) * A(i)) * (_problem.f(X[i]) + sum);
            }
            return Y;
        }


        public double[] SimpleIterationSolve(double error)
        {
            Y = new double[Y.Length];
            var Yp = new double[Y.Length];
            int k = 0;
            double reY = 1;
            double reYp = 2;
            while ( Math.Abs(reY - reYp) > error)
            {
                k++;
                Yp = Y;
                reYp = reY;
                for (int i = 0; i < Y.Length; i++)
                {
                    double sum = 0;
                    for (int j = 0; j <= i; j++)
                    {
                        sum += _problem.K(X[i], X[j]) * YFunct(Yp[j]) * A(j);
                    }

                    Y[i] = _problem.f(X[i]) + sum;
                }
                reY = RelativeError(Y);
                Console.WriteLine("iter num " + k + "\tRelativeError " + RelativeError(Y) + "\terror " + error);
            }
            
            return Y;
        }

        public double[] DegenerateCoreSolve()
        {

            return Y;
        }

    }
}
