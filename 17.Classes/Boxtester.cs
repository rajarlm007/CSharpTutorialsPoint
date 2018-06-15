using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Classes
{
    class Box
    {
        // static variables
        public static int count;

        // instance variables
        public double length;   // Length of a box
        public double breadth;  // Breadth of a box
        public double height;   // Height of a box

        // contructor 

        public Box()
        {
            length = 40;
            breadth = 20;
            height = 15;
            count++;
        }


        /*    C# Destructors

        A destructor is a special member function of a class that is executed
        whenever an object of its class goes out of scope. A destructor has 
        exactly the same name as that of the class with a prefixed tilde (~)
        and it can neither return a value nor can it take any parameters.

        Destructor can be very useful for releasing memory resources before
        exiting the program. Destructors cannot be inherited or overloaded
        
        Destructors are invoked automatically, and cannot be invoked explicitly.
        
        Destructors cannot be overloaded. Thus, a class can have, at most, one destructor.
        
        Destructors are not inherited. Thus, a class has no destructors other than the one, which may be declared in it.
        
        Destructors cannot be used with structs. They are only used with classes.
        
        An instance becomes eligible for destruction when it is no longer possible for any code to use the instance.
        
        Execution of the destructor for the instance may occur at any time after the instance becomes eligible for destruction.
        
        When an instance is destructed, the destructors in its inheritance chain are called, in order, from most derived to least derived.
             
        */

        ~Box()
        {
            Console.WriteLine("Object is being deleted");
        }

        // class methods
        public void setLength(double length)
        {
            this.length = length;
        }
        public void setBreadth(double breadth)
        {
            this.breadth = breadth;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public double getVolume()
        {
            return length * breadth * height;
        }

        public double getCount()
        {
            return count;
        }
    }

    class Boxtester
    {
        static void Main(string[] args)
        {
            Box Box1 = new Box();   // Declare Box1 of type Box
            Box Box2 = new Box();
            double volume;

            // Declare Box2 of type Box
            // box 1 specification
            Box1.setLength(6.0);
            Box1.setBreadth(7.0);
            Box1.setHeight(5.0);

            // box 2 specification
            Box2.setLength(12.0);
            Box2.setBreadth(13.0);
            Box2.setHeight(10.0);

            // volume of box 1
            volume = Box1.getVolume();
            Console.WriteLine("Volume of Box1 : {0}", volume);

            // volume of box 2
            volume = Box2.getVolume();
            Console.WriteLine("Volume of Box2 : {0}", volume);

            Console.ReadKey();
        }
    }
}
