using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9507
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double f=1000, r=1600, c= 0.000006;
            double Av = 1.0 / (1 + 2 * 3.14 * f * r * c );
            double z = 20 * Math.Log10(Av);
            Console.ReadKey();
        }
    }
}
