using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _9505
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s=Console.ReadLine().Split(' ');
            int water = int.Parse(s[0]), dan = int.Parse(s[1]);
            int wlevel = 0, dlevel = 0;
            if(water<50) wlevel = 1;
            if (water >= 50 && water <= 100) wlevel = 2;
            if(water>100) wlevel = 3;
            if (dan < 100) dlevel = 1;
            if(dan>=100&&dan<=200) dlevel = 2;
            if(dan>200) dlevel = 3;
            double all = 0;
            if (wlevel == 1 && dlevel == 1)
            {
                all = (water * 5 + dan * 5) / 2.0 * 0.6;
            }
            else if ((wlevel == 2 && dlevel == 1) || (wlevel == 1 && dlevel == 2))
            {
                all = (water * 5 + dan * 5) / 2.0 * 0.8;
            }
            else if (wlevel == 3 && dlevel == 3) all = (water * 5 + dan * 5) / 2.0 + (water * 5 + dan * 5) / 2.0 * 0.4;
            else if (wlevel == 2 && dlevel == 3 || wlevel == 3 && dlevel == 2) all = (water * 5 + dan * 5) / 2.0 + (water * 5 + dan * 5) / 2.0 * 0.2;
            else all = (water * 5 + dan * 5) / 2.0;
            Console.WriteLine(all);
            Console.ReadKey();
        }
    }
}
