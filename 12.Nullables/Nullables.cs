using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Nullables
{

    /*
    you can store any value from -2,147,483,648 to 
    2,147,483,647 or null in a Nullable<Int32> variable
    */
    class Nullables
    {
        /* Declaring a nullable type:
         < data_type> ? <variable_name> = null; */
        static void Main(string[] args)
        {
            int? num1 = null;
            int? num2 = 45;

            double? num3 = new double?();
            double? num4 = 3.14157;

            bool? boolval = new bool?();

            // display the values
            Console.WriteLine("Nullables at Show: {0}, {1}, {2}, {3}", num1, num2, num3, num4);
            Console.WriteLine("A Nullable boolean value: {0}", boolval);


            // Null Coalescing Operator is used for converting an operand to the type of another nullable
            // If the value of the first operand is null, then the operator returns the value of the second
            // operand, otherwise it returns the value of the first operand.
            num3 = num1 ?? 5.34;
            Console.WriteLine(" Value of num3: {0}", num3);
            num3 = num2 ?? 5.34;
            Console.WriteLine(" Value of num3: {0}", num3);
            Console.ReadLine();
        }
    }
}
    