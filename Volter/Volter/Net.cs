using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volter
{
    class Net
    {
        public double[] NetStep { get; private set; }
        public double[] X { get; private set; }
        public double[] Y { get; set; }
        private double _intervalStart;
        private double _intervalEnd;

        public void SetConstNetStep(double step)
        {
            X = new double[(int)((_intervalEnd - _intervalStart) / step)];
            NetStep = new double[X.Length];
            Y = new double[X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                NetStep[i] = step;
                X[i] = _intervalStart + i * step;
            }
        }

        #region Constructors
        public Net(double netStep, double intervalStart, double intervalEnd)
        {
            if (intervalStart >= intervalEnd) throw new Exception("wrong interval");
            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;
            int length = (int)((intervalEnd - intervalStart) / netStep);
            X = new double[length];
            NetStep = new double[length];
            Y = new double[length];
            SetConstNetStep(netStep);
        }

        public Net(double[] netStep, double intervalStart, double intervalEnd)
        {
            if (intervalStart >= intervalEnd) throw new Exception("wrong interval");

            _intervalStart = intervalStart;
            _intervalEnd = intervalEnd;

            int length = netStep.Length;
            NetStep = netStep;
            X = new double[length];

            X[0] = intervalStart;
            for (int i = 1; i < length; i++)
            {
                X[i] = X[i - 1] + NetStep[i - 1];
            }
        }

        public Net(Func<double,double> rule, double intervalStart, double intervalEnd)
        {
            if (intervalStart >= intervalEnd) throw new Exception("wrong interval");
            throw new NotImplementedException();
        }
        public Net(double netStep, Problem zadacha) 
            : this(netStep, zadacha.IntervalStart, zadacha.IntervalEnd) { }
        public Net(double[] netStep, Problem zadacha)
            : this(netStep, zadacha.IntervalStart, zadacha.IntervalEnd) { }
        #endregion
    }
}
