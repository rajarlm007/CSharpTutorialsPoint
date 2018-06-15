using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Inheritance
{

    public interface PaintCost
    {
        void getCost(double area);
    }

    class Rectangle : Shape, PaintCost // mulitple inheritance class ana interface
    {
        public Rectangle()
        {
        }

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public double GetArea()
        {
            return (width * height);
        }

        public void getCost(double area)
        {
            Console.WriteLine("no cost has been set");
        }

        public void Display()
        {
            Console.WriteLine("Length: {0}", height);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}
