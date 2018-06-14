using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Arrays
{
    class TwoDimensionalArrayExamlpe
    {
        public static void Exec()
        {
            int[,] a = new int[3, 4] {
               {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
               {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
               {8, 9, 10, 11}   /*  initializers for row indexed by 2 */
            };

            int[,] b = new int[5, 2] { { 0, 0 }, { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 } };
            Console.WriteLine("Multidimential array:");
            int i, j;
            /* output each array element's value */
            for (i = 0; i < 5; i++)
            {

                for (j = 0; j < 2; j++)
                {
                    Console.WriteLine("b[{0},{1}] = {2}", i, j, b[i, j]);
                }
            }
        }
    }
}
