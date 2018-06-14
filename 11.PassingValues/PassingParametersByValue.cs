using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PassingValues
{
    class PassingParametersByValue
    {
        /*
        When using primitives,the values of the actual parameters are copied
        into them. Hence, the changes made to the parameter inside the method
        have no effect on the argument.
         */
        public void SwapByVal(int x, int y)
        {
            int temp;

            temp = x; /* save the value of x */
            x = y;    /* put y into x */
            y = temp; /* put temp into y */
        }
    }
}
