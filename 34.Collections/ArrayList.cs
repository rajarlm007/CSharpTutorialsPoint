using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34.Collections
{
    class ArrayListClass
    {

        public static void ExecuteArrayList()
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

        public static void ListExecute()
        {
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


        public static void HashTableExecute()
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

        public static void HashSetExcute()
        {
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

        public static void SortedListExecute()
        {
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

        public static void DictionaryExecute()
        {
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
    }
}

