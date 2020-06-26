using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Arrays
{
    class ArrayDeclaration
    {
        public static void Exec()
        {
            int[] n = new int[10]; /* n is an array of 10 integers */
            int i, j;

            /* initialize elements of array n */
            for (i = 0; i < 10; i++)
            {
                n[i] = i + 100;
            }

            /* output each array element's value */
            for (j = 0; j < 10; j++)
            {
                Console.WriteLine("Element[{0}] = {1}", j, n[j]);
            }
        }

        public static void DeclareArrays()
        {
            int[] arr = new int[5] { 10, 20, 30, 40, 50 };
            int[] arr1 = new int[] { 10, 20, 30, 40, 50 };
            int[] arr2 = { 10, 20, 30, 40, 50 };
            int i, j;

        }
    }
}
