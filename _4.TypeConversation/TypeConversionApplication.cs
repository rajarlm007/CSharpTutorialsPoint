using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversionApplication
{
    class ExplicitConversion
    {
        static void Main(string[] args)
        {
            double d = 5673.7564;
            // cast double to int.
            int dCon = (int)d;
            Console.WriteLine("doule {0} is converted explicitly (casted) to int {1}", d, dCon);

            int i = 75;
            float f = 53.005f;
            double dob = 2345.7652;
            bool b = true;
            Console.WriteLine(i.ToString());
            Console.WriteLine(f.ToString());
            Console.WriteLine(dob.ToString());
            Console.WriteLine(b.ToString());
            Console.ReadKey();

        }
    }
}