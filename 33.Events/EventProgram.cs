using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33.Events
{
    /*
    Events are user actions such as key press, clicks, mouse movements, 
    etc., or some occurrence such as system generated notifications. 
    Applications need to respond to events when they occur. For example,
    interrupts. Events are used for inter-process communication.
    */

    public delegate string MyDel(string str);
    class EventProgram
    {
        event MyDel MyEvent;

        public EventProgram()
        {
            this.MyEvent += new MyDel(this.WelcomeUser);
        }
        public string WelcomeUser(string username)
        {
            return "Welcome " + username;
        }
        static void Main(string[] args)
        {
            EventProgram obj1 = new EventProgram();
            string result = obj1.MyEvent("Tutorials Point");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
