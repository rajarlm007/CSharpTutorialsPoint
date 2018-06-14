using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PassingValues
{
    class PassingParametersByOutput
    {
        /*
        A return statement can be used for returning only one value 
        from a function. However, using output parameters, you can 
        return two values from a function. Output parameters are 
        similar to reference parameters, except that they transfer 
        data out of the method rather than into it.
         */
        public void getValue(out int x)
        {
            int temp = 5;
            x = temp;
            /*
            When the above code is compiled and executed, it produces the
            following result −
            Before method call, value of a : 100
            After method call, value of a : 5 
            */
        }

        public void getValues(out int x, out int y)
        {
            Console.WriteLine("Enter the first value: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second value: ");
            y = Convert.ToInt32(Console.ReadLine());
        }
    }
}
