using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PassingValues
{
    class Executor
    {
        static void Main(string[] args)
        {
            PassingParametersByValue n = new PassingParametersByValue();
            PassingParametersByReference m = new PassingParametersByReference();
            int a = 100;
            int b = 200;

            Console.WriteLine("Before swap by value, value of a : {0}", a);
            Console.WriteLine("Before swap by value, value of b : {0}", b);
            n.SwapByVal(a, b);    /* calling a function to swap the values */
            Console.WriteLine("After swap by value, value of a : {0}", a);
            Console.WriteLine("After swap by value, value of b : {0}", b);

            Console.WriteLine("Before swap by reference, value of a : {0}", a);
            Console.WriteLine("Before swap by reference, value of b : {0}", b);
            m.SwapByRef(ref a, ref b);
            Console.WriteLine("After swap by reference, value of a : {0}", a);
            Console.WriteLine("After swap by reference, value of b : {0}", b);

            PassingParametersByOutput k = new PassingParametersByOutput();
            /* local variable only defined */
            int x, y;
            /* calling a function to get the values */
            k.getValues(out x, out y);

            Console.WriteLine("After method call, value of x : {0}", x);
            Console.WriteLine("After method call, value of y : {0}", y);

            Console.ReadLine();
        }
    }
}
