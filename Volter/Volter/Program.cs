using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var f2s = new Form1("Second Problem Simpson", true);
            var f2lr = new Form1("Second Problem Left Rectangles", true);
            var f2sn = new Form1("Second Problem Simpson Nonlinear", true);
            var f1 = new Form1("First Problem", true);

            var f1err = new Form1("First Problem Errors");
            f1err.AddLine("Errors");
            f1err.AddLine("Straight Line");
            f1err.AddXY("Straight Line", 0.25, 0.109942);
            f1err.AddXY("Straight Line", 0.0019, 0.001);

            var p = new Problem(0, 1);
            var n = new Net(0.1, p);
            var s = new Solver(n, p);

            var p3 = new Problem(0, 1, MyFunctions.X_ExpXSMinus1_, MyFunctions.ExpXMinusX);
            var n3 = new Net(0.1, p3);
            var s3 = new Solver(n3, p3);
            
            for (double i = 0.25; i >= 0.001; i/=2)
            {
                n.SetConstNetStep(i);

                s.Quadrature = Quadratures.Trapeze;
                s.QuadratureSolve();
                f1.AddLine(i.ToString(), s.X, s.Y);
                f1err.AddXY("Errors", i, s.RelativeError(s.Y));

                s.Quadrature = Quadratures.Simpson;

                s.SimpleIterationSolve(0.001);
                f2s.AddLine(i.ToString(), s.X, s.Y);

                s.YFunct = MyFunctions.SquaredX;
                s.SimpleIterationSolve(0.001);
                f2sn.AddLine(i.ToString(), s.X, s.Y);

                s.YFunct = MyFunctions.X;

                s.Quadrature = Quadratures.LeftRectangle;
                s.SimpleIterationSolve(0.001);
                f2lr.AddLine(i.ToString(), s.X, s.Y);
            }
            
            Application.EnableVisualStyles();
            f1.Show();
            f1err.Show();
            f2lr.Show();
            f2sn.Show();
            Application.Run(f2s);

        }
    }
}
