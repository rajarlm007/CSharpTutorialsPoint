using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Arrays
{
    class ParamsArrays
    {
        /*
         At times, while declaring a method, you are not sure of the 
         number of arguments passed as a parameter. C# param arrays 
         (or parameter arrays) come into help at such times. 
         */
        static public int AddElements(params int[] arr)
        {
            int sum = 0;

            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
        public static void Exec()
        {
            int sum = AddElements(512, 720, 250, 567, 889);

            Console.WriteLine("The sum is: {0}", sum);
        }
    }
}
