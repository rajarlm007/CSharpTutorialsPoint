using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Polymorphism
{
    class Shape
    {
        protected double width, height;
        public Shape(double a = 0, double b = 0)
        {
            width = a;
            height = b;
        }

        /*
        When you have a function defined in a class that you want to be implemented 
        in an inherited class(es), you use virtual functions. The virtual functions
        could be implemented differently in different inherited class and the call 
        to these functions will be decided at runtime.
        Dynamic polymorphism is implemented by abstract classes and virtual functions.
        */
        public virtual double Аrea()
        {
            Console.WriteLine("Parent class area :");
            return 0;
        }

    }
}
