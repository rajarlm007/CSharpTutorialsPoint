using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.InternalAccess
{

    /*
    Internal access specifier allows a class to expose its member 
    variables and member functions to other functions and objects
    in the current assembly. In other words, any member with 
    internal access specifier can be accessed from any class or 
    method defined within the application in which the member is 
    defined.
     */

    class RectangleApplicationExample
    {
        class Rectangle
        {
            //member variables
            /*
             When a public class is declared as internal, it’s accessible 
             from the assembly containing this class, but hidden from any
             other assembly using it.
             */
            internal double length;
            internal double width;

            double GetArea()
            {
                return length * width;
            }
            public void Display()
            {
                Console.WriteLine("Length: {0}", length);
                Console.WriteLine("Width: {0}", width);
                Console.WriteLine("Area: {0}", GetArea());
            }
        }//end class Rectangle

        class ExecuteRectangle
        {
            static void Main(string[] args)
            {
                Rectangle r = new Rectangle();
                r.length = 4.5;
                r.width = 3.5;
                r.Display();
                Console.ReadLine();
            }
        }
    }
}
