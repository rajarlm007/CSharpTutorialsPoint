using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Polymorphism
{
    class Caller
    {
        public void CallArea(Shape sh)
        {
            double a;
            a = sh.Аrea();
            Console.WriteLine("Area: {0}", a);
        }
    }

    class Tester
    {
        static void Main(string[] args)
        {
            Caller c = new Caller();
            Rectangle r = new Rectangle(10, 7);
            c.CallArea(r);

            Triangle t = new Triangle(10, 5);
            c.CallArea(t);
            Console.ReadKey();
        }
    }
}
