using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.Namespaces
{
    /*
    A namespace is designed for providing a way to keep one set of names 
    separate from another. The class names declared in one namespace 
    does not conflict with the same class names declared in another.
    The using keyword states that the program is using the names in the 
    given namespace.

    You can also avoid prepending of namespaces with the using namespace
    directive. This directive tells the compiler that the subsequent code
    is making use of names in the specified namespace.
    */

    namespace First_space
    {
        class Namespace_cl
        {
            public void Func()
            {
                Console.WriteLine("Inside first_space");
            }
        }
    }

    namespace Second_space
    {
        class namespace_cl
        {
            public void Func()
            {
                Console.WriteLine("Inside second_space");
            }
        }
    }

    namespace Nested_namespace_1
    {
        // code declarations

        namespace Nested_namespace_2
        {
            // code declarations
        }
    }

    class TestClass
    {
        static void Main(string[] args)
        {
            First_space.Namespace_cl fc = new First_space.Namespace_cl();
            Second_space.namespace_cl sc = new Second_space.namespace_cl();
            fc.Func();
            sc.Func();
            Console.ReadKey();
        }
    }
}
