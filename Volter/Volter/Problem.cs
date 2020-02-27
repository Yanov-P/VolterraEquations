using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volter
{
    class Problem
    {
        public double IntervalStart { get; }
        public double IntervalEnd { get; }
        public Func<double, double, double> K { get; }
        public Func<double, double> f { get; }
        private double DefaultK(double x, double s)
        {
            return Math.Exp(-x + s);
        }

        private double DefaultF(double x)
        {
            return Math.Exp(-x);
        }
        public Problem(double intervalStart, double intervalEnd)
        {
            IntervalStart = intervalStart;
            IntervalEnd = intervalEnd;
            K = DefaultK;
            f = DefaultF;
        }

        public Problem(double intervalStart, double intervalEnd, Func<double, double> f)
            : this(intervalStart, intervalEnd)
        {
            this.f = f;
        }
        public Problem(double intervalStart, double intervalEnd, Func<double, double, double> K) 
            : this(intervalStart, intervalEnd)
        {
            this.K = K;
        }

        public Problem(double intervalStart, double intervalEnd, Func<double, double, double> K, Func<double, double> f)
            : this(intervalStart, intervalEnd)
        {
            this.K = K;
            this.f = f;
        }
    }
}
