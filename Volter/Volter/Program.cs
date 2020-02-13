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
            var zadacha = new ZadachaVolter();
            var f = new Form1();
            var f1 = new Form1();

            f.ClearLines();
            f.AddLine("Точное решение");
            f.AddXY("Точное решение", 0, 1);
            f.AddXY("Точное решение", 1, 1);

            f1.ClearLines();
            f1.AddLine("Относительные погрешности");
            f1.AddLine("Прямая");
            f1.AddXY("Прямая", 0, 0);
            f1.AddXY("Прямая", 0.25, 0.1);

            for (int j = 0; j < 8; j++)
            {
                string lineName = zadacha.h.ToString();
                f.AddLine(lineName);
                zadacha.SolveKvadr();
                for (int i = 0; i < zadacha.curRes.Length; i++)
                {
                    f.AddXY(lineName, zadacha.x(i), zadacha.curRes[i]);
                }
                f1.AddXY("Относительные погрешности", zadacha.h, zadacha.OtnositPogr());
                zadacha.h /= 2;
            }
            
            Application.EnableVisualStyles();
            f1.Show();
            Application.Run(f);
            
            //Application.Run(f1);
        }
    }
}
