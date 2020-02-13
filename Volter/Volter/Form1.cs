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

        public void AddXY(string name, double x, double y)
        {
            chart1.Series[name].Points.AddXY(x, y);
        }
    }
}
