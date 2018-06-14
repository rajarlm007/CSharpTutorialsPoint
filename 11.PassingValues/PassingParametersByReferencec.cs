using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PassingValues
{
    class PassingParametersByReference
    {
        /*
        A reference parameter is a reference to a memory location 
        of a variable. When you pass parameters by reference, unlike
        value parameters, a new storage location is not created for 
        these parameters. The reference parameters represent the same
        memory location as the actual parameters that are supplied to
        the method.
        You can declare the reference parameters using the "ref" keyword.
         */

        public void SwapByRef(ref int x, ref int y)
        {
            int temp;

            temp = x; /* save the value of x */
            x = y;    /* put y into x */
            y = temp; /* put temp into y */
        }
    }
}
