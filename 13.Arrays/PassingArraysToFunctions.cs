using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Arrays
{
    class PassingArraysToFunctions
    {
        public static void Exec()
        {

            /* an int array with 5 elements */
            int[] balance = new int[] { 1000, 2, 3, 17, 50 };
            double avg;

            /* pass pointer to the array as an argument */
            avg = getAverage(balance, 5);

            /* output the returned value */
            Console.WriteLine("Average value is: {0} ", avg);
        }

        static double getAverage(int[] arr, int size)
        {
            int i;
            double avg;
            int sum = 0;

            for (i = 0; i < size; ++i)
            {
                sum += arr[i];
            }
            avg = (double)sum / size;
            return avg;
        }
    }
}
