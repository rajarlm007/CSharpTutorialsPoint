using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Arrays
{
    class Executor
    {
        static void Main(string[] args)
        {
            ArrayDeclaration.Exec();
            TwoDimensionalArrayExamlpe.Exec();
            JaggedArrays.Exec();
            PassingArraysToFunctions.Exec();
            ParamsArrays.Exec();

            // some Array class examples
            int[] list = { 34, 72, 13, 44, 25, 30, 10 };
            int[] temp = list;
            Console.Write("Original Array: ");

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // reverse the array
            Array.Reverse(temp);
            Console.Write("Reversed Array: ");

            foreach (int i in temp)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //sort the array
            Array.Sort(list);
            Console.Write("Sorted Array: ");

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            /* find index:
            Searches for the specified object and returns the index of
            the first occurrence within the entire one-dimensional Array.
             */
            Console.Write(Array.IndexOf(list, 72));

            Console.ReadKey();
        }
    }
}
