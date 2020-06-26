using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34.Collections
{
    class CollectionsClassTest
    {
        /*In C#, collection represents group of objects. By the help of collections, we can perform various operations on objects such as
            store object
            update object
            delete object
            retrieve object
            search object, and
            sort object */

        public static void List_Execute()
        {
            //C# List<T> class is used to store and fetch elements. It can have duplicate elements. It is found in System.Collections.Generic namespace.
            //Let's see an example of generic List<T> class that stores elements using Add() method and iterates the list using for-each loop.

            List<string> words = new List<string>(); // New string-typed list
            words.Add("melon");
            words.Add("avocado");
            words.Add("Orange");
            words.Add("nannari");
            words.Add("apple");
            words.AddRange(new[] { "banana", "plum" });
            words.Insert(0, "lemon"); // Insert at start
            words.InsertRange(0, new[] { "peach", "nashi" }); // Insert at start
            words.Remove("melon");
            words.RemoveAt(3); // Remove the 4th element
            words.RemoveRange(0, 2); // Remove first 2 elements
                                     // Remove all strings starting in 'n':
            words.RemoveAll(s => s.StartsWith("n"));
            Console.WriteLine(words[0]); // first word
            Console.WriteLine(words[words.Count - 1]); // last word
            foreach (string s in words) Console.WriteLine(s); // all words
            List<string> subset = words.GetRange(1, 2); // 2nd->3rd words
            foreach (string ss in subset) Console.WriteLine(ss);
            string[] wordsArray = words.ToArray(); // Creates a new typed array
                                                   // Copy first two elements to the end of an existing array:
            string[] existing = new string[1000];
            words.CopyTo(0, existing, 998, 2);
            List<string> upperCastWords = words.ConvertAll(s => s.ToUpper());
            foreach (string h in upperCastWords) Console.WriteLine(h);
            List<int> lengths = words.ConvertAll(s => s.Length);
            foreach (var sa in lengths) Console.WriteLine(sa);
        }
        public static void ArrayList_Execute()
        {

            ArrayList al = new ArrayList();

            Console.WriteLine("Adding some numbers:");
            al.Add(45);
            al.Add(78);
            al.Add(33);
            al.Add(56);
            al.Add(12);
            al.Add(23);
            al.Add(9);
            Console.WriteLine("Capacity: {0} ", al.Capacity);
            Console.WriteLine("Count: {0}", al.Count);

            Console.Write("Content: ");
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.Write("Sorted Content: ");
            al.Sort();
            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void LinkedList_Execute()
        {
            //C# LinkedList<T> class uses the concept of linked list. It allows us to insert and delete elements fastly.
            //It can have duplicate elements. It is found in System.Collections.Generic namespace.
            //It allows us to add and remove element at before or last index.

            // Create a list of strings  
            var names = new LinkedList<string>();
            names.AddLast("Sonoo Jaiswal");
            names.AddLast("Ankit");
            names.AddLast("Peter");
            names.AddLast("Irfan");
            names.AddFirst("John");//added to first index  

            // Iterate list element using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        
        public static void HashSet_Excute()
        {
            //C# HashSet class can be used to store, remove or view elements. It does not store duplicate elements. 
            //It is suggested to use HashSet class if you have to store only unique elements. It is found in System.Collections.Generic namespace.

            HashSet<string> employees = new HashSet<string>(new string[]
            {"Fred","Bert","Harry","John"});
            HashSet<string> customers = new HashSet<string>(new string[]
            {"John","Sid","Harry","Diana"});
            employees.Add("James");
            customers.Add("Francesca");
            Console.WriteLine("Employees:");
            foreach (string name in employees)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("");
            Console.WriteLine("Customers:");
            foreach (string name in customers)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\nCustomers who are also employees:");
            customers.IntersectWith(employees);
            foreach (string name in customers)
            {
                Console.WriteLine(name);
            }
        }

        public static void Stack_Execute()
        {
            //C# Stack<T> class is used to push and pop elements. It uses the concept of Stack that arranges elements in LIFO (Last In First Out) order. 
            //It can have duplicate elements. It is found in System.Collections.Generic namespace.
            //Let's see an example of generic Stack<T> class that stores elements using Push() method, removes elements using Pop() method and iterates elements using for-each loop.
            Stack<string> names = new Stack<string>();
            names.Push("Sonoo");
            names.Push("Peter");
            names.Push("James");
            names.Push("Ratan");
            names.Push("Irfan");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Peek element: " + names.Peek());
            Console.WriteLine("Pop: " + names.Pop());
            Console.WriteLine("After Pop, Peek element: " + names.Peek());

        }
        public static void Queue_Execute()
        {
            //C# Queue<T> class is used to Enqueue and Dequeue elements. It uses the concept of Queue that arranges elements in FIFO (First In First Out) order.
            //It can have duplicate elements. It is found in System.Collections.Generic namespace.
            //Let's see an example of generic Queue<T> class that stores elements using Enqueue() method, removes elements using Dequeue() method and iterates elements using for-each loop.
            Queue<string> names = new Queue<string>();
            names.Enqueue("Sonoo");
            names.Enqueue("Peter");
            names.Enqueue("James");
            names.Enqueue("Ratan");
            names.Enqueue("Irfan");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Peek element: " + names.Peek());
            Console.WriteLine("Dequeue: " + names.Dequeue());
            Console.WriteLine("After Dequeue, Peek element: " + names.Peek());
        }




        public static void HashTable_Execute()
        {
            Hashtable ht = new Hashtable();

            ht.Add("001", "Zara Ali");
            ht.Add("002", "Abida Rehman");
            ht.Add("003", "Joe Holzner");
            ht.Add("004", "Mausam Benazir Nur");
            ht.Add("005", "M. Amlan");
            ht.Add("006", "M. Arif");
            ht.Add("007", "Ritesh Saikia");

            if (ht.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                ht.Add("008", "Nuha Ali");
            }

            // Get a collection of the keys.
            ICollection key = ht.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + ht[k]);
            }
            Console.ReadKey();
        }

        public static void Dictionary_Execute()
        {
            //C# Dictionary<TKey, TValue> class uses the concept of hashtable. It stores values on the basis of key.
            //It contains unique keys only. By the help of key, we can easily search or remove elements. It is found in System.Collections.Generic namespace.
            
            Dictionary<string, int> ages = new Dictionary<string, int>();
            // fill the Dictionary
            ages.Add("John", 53); // using the Add method
            ages.Add("Diana", 53);
            ages["James"] = 26; // using array notation
            ages["Francesca"] = 23;
            // iterate using a foreach statement
            // the iterator generates a KeyValuePair item
            Console.WriteLine("The Dictionary contains:");
            foreach (KeyValuePair<string, int> element in ages)
            {
                string name = element.Key;
                int age = element.Value;
                Console.WriteLine($"Name: , Age: ");
            }
        }

        public static void SortedDictionary_Execute()
        {
            //C# SortedDictionary<TKey, TValue> class uses the concept of hashtable. It stores values on the basis of key.
            //It contains unique keys and maintains ascending order on the basis of key.
            //By the help of key, we can easily search or remove elements. It is found in System.Collections.Generic namespace.
            
            SortedDictionary<string, string> names = new SortedDictionary<string, string>();
            names.Add("1", "Sonoo");
            names.Add("4", "Peter");
            names.Add("5", "James");
            names.Add("3", "Ratan");
            names.Add("2", "Irfan");
            foreach (KeyValuePair<string, string> kv in names)
            {
                Console.WriteLine(kv.Key + " " + kv.Value);
            }
        }
        public static void SortedSet_Excute()
        {
            //C# SortedSet class can be used to store, remove or view elements. It maintains ascending order and does not store duplicate elements.
            //It is suggested to use SortedSet class if you have to store unique elements and maintain ascending order. It is found in System.Collections.Generic namespace.
           
            // Create a set of strings  
            var names = new SortedSet<string>();
            names.Add("Sonoo");
            names.Add("Ankit");
            names.Add("Peter");
            names.Add("Irfan");
            names.Add("Ankit");//will not be added  

            // Iterate SortedSet elements using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void SortedList_Execute()
        {
            //C# SortedList<TKey, TValue> is an array of key/value pairs. It stores values on the basis of key.
            //The SortedList<TKey, TValue> class contains unique keys and maintains ascending order on the basis of key.
            //By the help of key, we can easily search or remove elements. It is found in System.Collections.Generic namespace.
            //It is like SortedDictionary < TKey, TValue > class.

            SortedList sl = new SortedList();
            sl.Add("001", "Zara Ali");
            sl.Add("003", "Joe Holzner");
            sl.Add("005", "M. Amlan");
            sl.Add("002", "Abida Rehman");
            sl.Add("006", "M. Arif");
            sl.Add("007", "Ritesh Saikia");
            sl.Add("004", "Mausam Benazir Nur");

            if (sl.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                sl.Add("008", "Nuha Ali");
            }

            // get a collection of the keys. 
            ICollection key = sl.Keys;
            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + sl[k]);
            }

            ICollection vals = sl.Values;
            foreach (string v in vals)
            {
                Console.WriteLine(v + ": " + sl[v]);
            }
        }


    }
}

