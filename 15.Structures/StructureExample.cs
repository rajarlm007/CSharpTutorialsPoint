using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Structures
{
    /*
    In C#, a structure is a value type data type. It helps you to make a single 
    variable hold related data of various data types. The struct keyword is used
    for creating a structure. Structures are used to represent a record.
    
    Classes are reference types and structs are value types
    
    Structures do not support inheritance
    
    Structures cannot have default constructor
    
    Structures can have methods, fields, indexers, properties, operator methods, and events.

    Structures can have defined constructors, but not destructors. However, you cannot define
    a default constructor for a structure. The default constructor is automatically defined 
    and cannot be changed.

    Unlike classes, structures cannot inherit other structures or classes.

    Structures cannot be used as a base for other structures or classes.

    A structure can implement one or more interfaces.

    Structure members cannot be specified as abstract, virtual, or protected.

    When you create a struct object using the New operator, it gets created and the appropriate
    constructor is called. Unlike classes, structs can be instantiated without using the New operator.

    If the New operator is not used, the fields remain unassigned and the object cannot be 
    used until all the fields are initialized.     
         
     */
    struct Books
    {
        public string title;
        public string author;
        public string subject;
        public int book_id;
    };

    public class TestStructure
    {
        public static void Main(string[] args)
        {
            Books Book1;   /* Declare Book1 of type Book */
            Books Book2;   /* Declare Book2 of type Book */

            /* book 1 specification */
            Book1.title = "C Programming";
            Book1.author = "Nuha Ali";
            Book1.subject = "C Programming Tutorial";
            Book1.book_id = 6495407;

            /* book 2 specification */
            Book2.title = "Telecom Billing";
            Book2.author = "Zara Ali";
            Book2.subject = "Telecom Billing Tutorial";
            Book2.book_id = 6495700;

            /* print Book1 info */
            Console.WriteLine("Book 1 title : {0}", Book1.title);
            Console.WriteLine("Book 1 author : {0}", Book1.author);
            Console.WriteLine("Book 1 subject : {0}", Book1.subject);
            Console.WriteLine("Book 1 book_id :{0}", Book1.book_id);

            /* print Book2 info */
            Console.WriteLine("Book 2 title : {0}", Book2.title);
            Console.WriteLine("Book 2 author : {0}", Book2.author);
            Console.WriteLine("Book 2 subject : {0}", Book2.subject);
            Console.WriteLine("Book 2 book_id : {0}", Book2.book_id);

            Console.ReadKey();
        }
    }
}
