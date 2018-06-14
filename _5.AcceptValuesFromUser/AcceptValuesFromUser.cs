using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptValuesFromUser
{
    class AcceptValuesFromUser
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("tell me some random integer");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} is valid integer", num);
            Console.ReadKey();
        }
    }
}
