using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Methods
{
    class CallingMethodsExample
    {
        public int FindMax(int num1, int num2)
        {
            /* local variable declaration */
            int result;

            if (num1 > num2)
                result = num1;
            else
                result = num2;
            return result;
        }

        static void Main(string[] args)
        {
            /* local variable definition */
            int a = 100;
            int b = 200;
            int ret;
            CallingMethodsExample n = new CallingMethodsExample();

            //calling the FindMax method
            ret = n.FindMax(a, b);
            Console.WriteLine("Max value is : {0}", ret);

            // no problem calling public method of other classes
            RecursionMethodCall m = new RecursionMethodCall();
            //calling the factorial method {0}", n.factorial(6));
            Console.WriteLine("Factorial of 7 is : {0}", m.Factorial(7));
            Console.WriteLine("Factorial of 8 is : {0}", m.Factorial(8));
            Console.ReadLine();
        }
    }

    class RecursionMethodCall
    {
        public int Factorial(int num)
        {
            /* local variable declaration */
            int result;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                result = Factorial(num - 1) * num;
                return result;
            }
        }
    }
}
