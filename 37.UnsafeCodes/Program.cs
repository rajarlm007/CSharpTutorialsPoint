using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37.UnsafeCodes
{
    /*
    C# allows using pointer variables in a function of code block when it 
    is marked by the unsafe modifier. The unsafe code or the unmanaged code
    is a code block that uses a pointer variable.

    mcs *.cs -out:main.exe -unsafe"
    */

    class TestPointer
    {
        public unsafe void swap(int* p, int* q)
        {
            int temp = *p;
            *p = *q;
            *q = temp;
        }
        public unsafe static void Main()
        {
            TestPointer p = new TestPointer();
            int var1 = 10;
            int var2 = 20;
            int* x = &var1;
            int* y = &var2;

            Console.WriteLine("Before Swap: var1:{0}, var2: {1}", var1, var2);
            p.swap(x, y);

            Console.WriteLine("After Swap: var1:{0}, var2: {1}", var1, var2);
            Console.ReadKey();
        }
    }
}
