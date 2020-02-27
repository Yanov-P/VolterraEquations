using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearLines();
        }

        //public Form1(string name) : this()
        //{
        //    this.Text = name;
        //}

        public Form1(string name, bool createWithExactSol = false) : this()
        {
            this.Text = name;
            if (createWithExactSol)
            {
                AddLine("Exact Solution");
                AddXY("Exact Solution", 0, 1);
                AddXY("Exact Solution", 1, 1);
            }
        }
        public void ClearLines()
        {
            chart1.Series.Clear();
        }
        public void AddLine(string name)
        {
            chart1.Series.Add(name);
            chart1.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
        }

        public void AddLine(string name, double[] x, double[] y)
        {
            chart1.Series.Add(name);
            chart1.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series[name].Points.AddXY(x[i], y[i]);
            }
            
        }
        public void AddXY(string name, double x, double y)
        {
            chart1.Series[name].Points.AddXY(x, y);
        }
    }
}
