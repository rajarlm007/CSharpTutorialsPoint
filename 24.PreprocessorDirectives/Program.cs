#define DEBUG
#define VC_V10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24.PreprocessorDirectives
{
    class Program
    {
        /*
        All preprocessor directives begin with #, and only white-space
        characters may appear before a preprocessor directive on a line.
        Preprocessor directives are not statements, so they do not end 
        with a semicolon (;).

        1	#define     It defines a sequence of characters, called symbol.

        2	#undef      It allows you to undefine a symbol.

        3	#if         It allows testing a symbol or symbols to see if they evaluate to true.
        
        4	#else       It allows to create a compound conditional directive, along with #if.

        5	#elif       It allows creating a compound conditional directive.

        6	#endif      Specifies the end of a conditional directive.

        7	#line       It lets you modify the compiler's line number and (optionally) the file name output for errors and warnings.

        8	#error      It allows generating an error from a specific location in your code.

        9	#warning    It allows generating a level one warning from a specific location in your code.

        10	#region     It lets you specify a block of code that you can expand or collapse when using the outlining feature of the Visual Studio Code Editor.

        11	#endregion  It marks the end of a #region block.

        */
        static void Main(string[] args)
        {
#if (PI)
            Console.WriteLine("PI is defined");
#else
            Console.WriteLine("PI is not defined");
#endif
            Console.ReadKey();

#if (DEBUG && !VC_V10)
         Console.WriteLine("DEBUG is defined");
#elif (!DEBUG && VC_V10)
         Console.WriteLine("VC_V10 is defined");
#elif (DEBUG && VC_V10)
            Console.WriteLine("DEBUG and VC_V10 are defined");
#else
            Console.WriteLine("DEBUG and VC_V10 are not defined");
#endif
            Console.ReadKey();
        }
    }
}