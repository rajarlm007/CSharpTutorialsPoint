using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.ExceptionHandling
{
    class Program
    {

        /*  structure:
        try {
           // statements causing exception
        } catch( ExceptionName e1 ) {
           // error handling code
        } catch( ExceptionName e2 ) {
           // error handling code
        } catch( ExceptionName eN ) {
           // error handling code
        } finally {
           // statements to be executed
        }
         */

        int result;
        Program()
        {
            result = 0;
        }
        public void division(int num1, int num2)
        {
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
                try
                {
                    Console.WriteLine("Creating User-Defined Exception: ");
                    Temperature temp = new Temperature();
                    temp.showTemp();
                } catch (TempIsZeroException e)
            {
                Console.WriteLine("TempIsZeroException: {0}", e.Message);
            }
            Console.ReadKey();
        }
        }

        public class TempIsZeroException : Exception
        {
            public TempIsZeroException(string message) : base(message)
            {
            }
        }
        public class Temperature
        {
            int temperature = 0;

            public void showTemp()
            {

                if (temperature == 0)
                {
                    throw (new TempIsZeroException("Zero Temperature found"));
                }
                else
                {
                    Console.WriteLine("Temperature: {0}", temperature);
                }
            }
        }

        static void Main(string[] args)
        {
            Program d = new Program();
            d.division(25, 0);
            Console.ReadKey();
        }
    }
}
