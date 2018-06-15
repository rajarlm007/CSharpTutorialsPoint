using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Inheritance
{
    class Shape // Base Class
    {
        protected double width;
        protected double height;

        public void setWidth(double w)
        {
            width = w;
        }

        public void setHeight(double h)
        {
            height = h;
        }
    }
}
