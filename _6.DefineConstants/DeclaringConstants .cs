using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.DefineConstants
{ 
    class DeclaringConstants
    {
        static void Main(string[] args)
        {
            const double pi = 3.14159;
            Console.WriteLine("Our constant is pi = {0}", pi);
            // constant declaration 
            double r;
            Console.WriteLine("Enter Radius: ");
            r = Convert.ToDouble(Console.ReadLine());

            double areaCircle = pi * r * r;
            Console.WriteLine("Radius: {0}, Area: {1}", r, areaCircle);
            Console.ReadLine();
        }
    }
}