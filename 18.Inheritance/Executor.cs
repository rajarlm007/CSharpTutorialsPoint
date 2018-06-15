using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Inheritance
{
    class RectangleTester
    {
        static void Main(string[] args)
        {
            Rectangle Rect = new Rectangle();
            double area;

            Rect.setWidth(5.2);
            Rect.setHeight(7.3);
            area = Rect.GetArea();

            // Print the area of the object.
            Console.WriteLine("Total area: {0}", Rect.GetArea());
            Console.WriteLine("Total paint cost");
            Rect.getCost(area);
            Console.ReadKey();
        }
    }
}
