using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01_LTDT_1988216
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("======= CAU 1 ==========");
            Cau1 c1 = new Cau1();
            c1.Run();
            Console.WriteLine("");

            Console.WriteLine("======= CAU 2 ==========");
            Cau2 c2 = new Cau2();
            c2.Run();

            Console.ReadLine();
        }
    }
}
