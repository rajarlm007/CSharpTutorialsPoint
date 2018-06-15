using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Polymorphism
{
    class Rectangle : Shape
    {
        public Rectangle(double a = 0, double b = 0) : base(a, b)
        {
        }

        // override and inherited method
        public override double Аrea()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * height);
        }
    }

    class Triangle : Shape
    {
        public Triangle(double a = 0, double b = 0) : base(a, b)
        {
        }

        public override double Аrea()
        {
            Console.WriteLine("Triangle class area :");
            return (width * height / 2);
        }
    }
}
