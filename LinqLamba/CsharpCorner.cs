using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqLamba
{
    public class CsharpCorner
    {

        public static void Exec()
        {
            LinqSamples samples = new LinqSamples();
            samples.LConcat();
            samples.LDistinct();
            samples.LFirst();
            samples.LGroupBy();
            samples.LOrderByThenBy();
            samples.LSelectMany();
            samples.LSelectTest();
            samples.LSum();
            samples.LTakeSkipWhile();
            samples.LToDictionary();
            samples.LWhere();
        }

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }

        public class Order
        {
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal Total { get; set; }
        }

        public class Customer
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public Order[] Orders { get; set; }

        }

        private class LinqSamples
        {
            private readonly DataSet testDS;
            private List<Product> productList;
            private List<Customer> customerList;
            private List<Product> products;
            private List<Customer> orders;
            public LinqSamples()
            {
                testDS = LinqDataTable.TestHelper.CreateTestDataset();
                products = GetProductList();
                orders = GetCustomerList();
            }

            public void Linq2()
            {
               

            }

            public void LWhere()
            {
                IEnumerable<Product> x = products.Where(p => p.UnitPrice >= 10);

                IEnumerable<Product> y =
                from p in products
                where p.UnitPrice >= 10
                select p;
            }

            public void LSelectTest() {
                IEnumerable<string> productNames = products.Select(p => p.ProductName);
                IEnumerable<string> productNames1 = from p in products select p.ProductName;

                var namesAndPrices =
                products.
                Where(p => p.UnitPrice >= 10).
                Select(p => new { p.ProductName, p.UnitPrice }).
                ToList();
                IEnumerable<int> indices =
                products.
                Select((product, index) => new { product, index }).
                Where(x => x.product.UnitPrice >= 10).
                Select(x => x.index);
            }
            public void LSelectMany() {
                IEnumerable<Order> orders1 =
                orders.
                Where(c => c.Country == "Denmark").
                SelectMany(c => c.Orders);

                var namesAndOrderIDs1 =
                orders.
                Where(c => c.Country == "Denmark").
                SelectMany(c => c.Orders).
                Where(o => o.OrderDate.Year == 1996).
                Select(o => new { o.Total, o.OrderID });

                var namesAndOrderIDs2 =
                orders.
                Where(c => c.Country == "Denmark").
                SelectMany(c => c.Orders, (c, o) => new { c, o }).
                Where(co => co.o.OrderDate.Year == 2005).
                Select(co => new { co.c.CompanyName, co.o.OrderID });

                var namesAndOrderIDs3 =
                from c in this.orders
                where c.Country == "Denmark"
                from o in c.Orders
                where o.OrderDate.Year == 2005
                select new { c.CompanyName, o.OrderID };
            }
            public void LTakeSkipWhile() {
                IEnumerable<Product> MostExpensive10 = products.OrderByDescending(p => p.UnitPrice).Take(10);
                 // Skip
                IEnumerable<Product> AllButMostExpensive10 = products.OrderByDescending(p => p.UnitPrice).Skip(10);

                IEnumerable<Product> AllButMostExpensive11 = products.OrderByDescending(p => p.UnitPrice);
                //TakeWhile SkipWhile
                //s.TakeWhile(p)
                //s.SkipWhile(p)

            }
           
            public void LConcat()
            {
                IEnumerable<string> locations = orders.Select(c => c.City).
                Concat(orders.Select(c => c.Region)).
                Concat(orders.Select(c => c.Country)).
                Distinct();

                IEnumerable<string> locations2 = new[]
                {
                orders.Select(c => c.City),
                orders.Select(c => c.Region),
                orders.Select(c => c.Country),
                }.SelectMany(s => s).
                Distinct();

                IEnumerable<string> locations3 = orders.Select(c => c.City).Distinct();
            }

            public void LOrderByThenBy() {

                IEnumerable<Product> orderedProducts1 =
                products.
                OrderBy(p => p.Category).
                ThenByDescending(p => p.UnitPrice).
                ThenBy(p => p.ProductName);

                IEnumerable<Product> orderedProducts2 =
                from p in products
                orderby p.Category, p.UnitPrice descending, p.ProductName
                select p;

                IEnumerable<Product> orderedProducts3 =
                products.
                Where(p => p.Category == "Beverages").
                OrderBy(p => p.ProductName, StringComparer.CurrentCultureIgnoreCase);

                IEnumerable<string> orderedProductNames =
                products.
                Where(p => p.Category == "Beverages").
                Select(p => p.ProductName).
                OrderBy(x => x);
            }
            public void LGroupBy()
            {
                IEnumerable<IGrouping<string, Product>> productsByCategory = products.GroupBy(p => p.Category);
                IEnumerable<IGrouping<string, string>> productNamesByCategory = products.GroupBy(p => p.Category, p => p.ProductName);
            }
            public void LDistinct()
            {
                IEnumerable<string> productCategories = products.Select(p => p.Category).Distinct();
                // AsEnumerable
                List<Customer> custTable = GetCustomerList();// GetCustomersTable();
                var query = custTable.AsEnumerable().Where(c => c.Country == "UK");
                //ToArray
                string[] customerCountries = orders.Select(c => c.Country).Distinct().ToArray();
                //ToList
                List<Customer> customersWithOrdersIn2005 = orders.Where(c => c.Orders.Any(o => o.OrderDate.Year == 1996)).ToList();
            }

            public void LToDictionary()
            {
                Dictionary<int, Order> orders3 = orders.
                SelectMany(c => c.Orders).
                Where(o => o.OrderDate.Year == 1996).
                ToDictionary(o => o.OrderID);
                //Dictionary<string, decimal> categoryMaxPrice = products.
                //GroupBy(p => p.Category).
                //ToDictionary(g => g.Key, g => g.Group.Max(p => p.UnitPrice));
                //ToLookup
                //Lookup<string, Product> productsByCategory = products.ToLookup(p => p.Category);
                //IEnumerable<Product> beverages = productsByCategory["Beverage"];
                ////OfType
                //List<Person> persons = GetListOfPersons();
                //IEnumerable<Employee> employees = persons.OfType<Employee>();
                ////Cast
                //ArrayList objects = GetOrders();
                //IEnumerable<Order> ordersIn2005 =
                //objects.
                //Cast<Order>().
                //Where(o => o.OrderDate.Year == 2005);
                //ArrayList objects = GetOrders();
                //IEnumerable<Order> ordersIn2005 =
                //from Order o in objects
                //where o.OrderDate.Year == 2005
                //select o;
            }
            public void LFirst()
            {
                string phone = "981-443655";
                Customer c = orders.First(kc => kc.Phone == phone);
                //Single
                string id = "WARTH";
                Customer z = orders.Single(mc => mc.CustomerID == id);
                // ElementAt
                Product thirdMostExpensive = products.OrderByDescending(p => p.UnitPrice).ElementAt(2);
                //Range
                int[] squares = Enumerable.Range(0, 100).Select(v => v * v).ToArray();


                // Repeat
                long[] x = Enumerable.Repeat(-1L, 256).ToArray();
                //Empty
                IEnumerable<Customer> noCustomers = Enumerable.Empty<Customer>();
                //Any
                bool b = products.Any(p => p.UnitPrice >= 100 && p.UnitsInStock == 0);
                //All
                IEnumerable<string> fullyStockedCategories = products.
                GroupBy(p => p.Category).
                Where(g => g.All(p => p.UnitsInStock > 0)).
                Select(g => g.Key);
                //Count
                int count = orders.Count(u => u.City == "London");
            }
            public void LSum()
            {
                int year = 2005;
                var namesAndTotals = orders.
                Select(c => new
                {
                    c.CompanyName,
                    TotalOrders = c.Orders.
                    Where(o => o.OrderDate.Year == year).
                    Sum(o => o.Total)
                });

                //Min
                var minPriceByCategory = products.
                GroupBy(p => p.Category).
                Select(g => new
                {
                    Category = g.Key,
                    MinPrice = g.Min(p => p.UnitPrice)
                });

                //Max
                decimal largestOrder = orders.
                SelectMany(c => c.Orders).
                Where(o => o.OrderDate.Year == 1996).
                Max(o => o.Total);

                //Average
                var averageOrderTotals = orders.
                Select(c => new
                {
                    c.CompanyName,
                    AverageOrderTotal = c.Orders.Average(o => o.Total)
                });

                //Aggregate
                var longestNamesByCategory = products.
                GroupBy(p => p.Category).
                Select(g => new
                {
                    Category = g.Key,
                    LongestName = g.
                    Select(p => p.ProductName).
                    Aggregate((s, t) => t.Length > s.Length ? t : s)
                });
            }
                                                               

            public List<Product> GetProductList()
            {
                if (productList == null)
                    createLists();

                return productList;
            }

            public List<Customer> GetCustomerList()
            {
                if (customerList == null)
                    createLists();

                return customerList;
            }

            private void createLists()
            {
                // Product data created in-memory using collection initializer:
                productList =
                    new List<Product> {
                    new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
                    new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                    new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                    new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
                    new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.3500M, UnitsInStock = 0 },
                    new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.0000M, UnitsInStock = 120 },
                    new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.0000M, UnitsInStock = 15 },
                    new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.0000M, UnitsInStock = 6 },
                    new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.0000M, UnitsInStock = 29 },
                    new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 31 },
                    new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.0000M, UnitsInStock = 22 },
                    new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.0000M, UnitsInStock = 86 },
                    new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.0000M, UnitsInStock = 24 },
                    new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.2500M, UnitsInStock = 35 },
                    new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.5000M, UnitsInStock = 39 },
                    new Product { ProductID = 16, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17.4500M, UnitsInStock = 29 },
                    new Product { ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.0000M, UnitsInStock = 0 },
                    new Product { ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.5000M, UnitsInStock = 42 },
                    new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9.2000M, UnitsInStock = 25 },
                    new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", UnitPrice = 81.0000M, UnitsInStock = 40 },
                    new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", Category = "Confections", UnitPrice = 10.0000M, UnitsInStock = 3 },
                    new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", Category = "Grains/Cereals", UnitPrice = 21.0000M, UnitsInStock = 104 },
                    new Product { ProductID = 23, ProductName = "Tunnbröd", Category = "Grains/Cereals", UnitPrice = 9.0000M, UnitsInStock = 61 },
                    new Product { ProductID = 24, ProductName = "Guaraná Fantástica", Category = "Beverages", UnitPrice = 4.5000M, UnitsInStock = 20 },
                    new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", UnitPrice = 14.0000M, UnitsInStock = 76 },
                    new Product { ProductID = 26, ProductName = "Gumbär Gummibärchen", Category = "Confections", UnitPrice = 31.2300M, UnitsInStock = 15 },
                    new Product { ProductID = 27, ProductName = "Schoggi Schokolade", Category = "Confections", UnitPrice = 43.9000M, UnitsInStock = 49 },
                    new Product { ProductID = 28, ProductName = "Rössle Sauerkraut", Category = "Produce", UnitPrice = 45.6000M, UnitsInStock = 26 },
                    new Product { ProductID = 29, ProductName = "Thüringer Rostbratwurst", Category = "Meat/Poultry", UnitPrice = 123.7900M, UnitsInStock = 0 },
                    new Product { ProductID = 30, ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.8900M, UnitsInStock = 10 },
                    new Product { ProductID = 31, ProductName = "Gorgonzola Telino", Category = "Dairy Products", UnitPrice = 12.5000M, UnitsInStock = 0 },
                    new Product { ProductID = 32, ProductName = "Mascarpone Fabioli", Category = "Dairy Products", UnitPrice = 32.0000M, UnitsInStock = 9 },
                    new Product { ProductID = 33, ProductName = "Geitost", Category = "Dairy Products", UnitPrice = 2.5000M, UnitsInStock = 112 },
                    new Product { ProductID = 34, ProductName = "Sasquatch Ale", Category = "Beverages", UnitPrice = 14.0000M, UnitsInStock = 111 },
                    new Product { ProductID = 35, ProductName = "Steeleye Stout", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 20 },
                    new Product { ProductID = 36, ProductName = "Inlagd Sill", Category = "Seafood", UnitPrice = 19.0000M, UnitsInStock = 112 },
                    new Product { ProductID = 37, ProductName = "Gravad lax", Category = "Seafood", UnitPrice = 26.0000M, UnitsInStock = 11 },
                    new Product { ProductID = 38, ProductName = "Côte de Blaye", Category = "Beverages", UnitPrice = 263.5000M, UnitsInStock = 17 },
                    new Product { ProductID = 39, ProductName = "Chartreuse verte", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 69 },
                    new Product { ProductID = 40, ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.4000M, UnitsInStock = 123 },
                    new Product { ProductID = 41, ProductName = "Jack's New England Clam Chowder", Category = "Seafood", UnitPrice = 9.6500M, UnitsInStock = 85 },
                    new Product { ProductID = 42, ProductName = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", UnitPrice = 14.0000M, UnitsInStock = 26 },
                    new Product { ProductID = 43, ProductName = "Ipoh Coffee", Category = "Beverages", UnitPrice = 46.0000M, UnitsInStock = 17 },
                    new Product { ProductID = 44, ProductName = "Gula Malacca", Category = "Condiments", UnitPrice = 19.4500M, UnitsInStock = 27 },
                    new Product { ProductID = 45, ProductName = "Rogede sild", Category = "Seafood", UnitPrice = 9.5000M, UnitsInStock = 5 },
                    new Product { ProductID = 46, ProductName = "Spegesild", Category = "Seafood", UnitPrice = 12.0000M, UnitsInStock = 95 },
                    new Product { ProductID = 47, ProductName = "Zaanse koeken", Category = "Confections", UnitPrice = 9.5000M, UnitsInStock = 36 },
                    new Product { ProductID = 48, ProductName = "Chocolade", Category = "Confections", UnitPrice = 12.7500M, UnitsInStock = 15 },
                    new Product { ProductID = 49, ProductName = "Maxilaku", Category = "Confections", UnitPrice = 20.0000M, UnitsInStock = 10 },
                    new Product { ProductID = 50, ProductName = "Valkoinen suklaa", Category = "Confections", UnitPrice = 16.2500M, UnitsInStock = 65 },
                    new Product { ProductID = 51, ProductName = "Manjimup Dried Apples", Category = "Produce", UnitPrice = 53.0000M, UnitsInStock = 20 },
                    new Product { ProductID = 52, ProductName = "Filo Mix", Category = "Grains/Cereals", UnitPrice = 7.0000M, UnitsInStock = 38 },
                    new Product { ProductID = 53, ProductName = "Perth Pasties", Category = "Meat/Poultry", UnitPrice = 32.8000M, UnitsInStock = 0 },
                    new Product { ProductID = 54, ProductName = "Tourtière", Category = "Meat/Poultry", UnitPrice = 7.4500M, UnitsInStock = 21 },
                    new Product { ProductID = 55, ProductName = "Pâté chinois", Category = "Meat/Poultry", UnitPrice = 24.0000M, UnitsInStock = 115 },
                    new Product { ProductID = 56, ProductName = "Gnocchi di nonna Alice", Category = "Grains/Cereals", UnitPrice = 38.0000M, UnitsInStock = 21 },
                    new Product { ProductID = 57, ProductName = "Ravioli Angelo", Category = "Grains/Cereals", UnitPrice = 19.5000M, UnitsInStock = 36 },
                    new Product { ProductID = 58, ProductName = "Escargots de Bourgogne", Category = "Seafood", UnitPrice = 13.2500M, UnitsInStock = 62 },
                    new Product { ProductID = 59, ProductName = "Raclette Courdavault", Category = "Dairy Products", UnitPrice = 55.0000M, UnitsInStock = 79 },
                    new Product { ProductID = 60, ProductName = "Camembert Pierrot", Category = "Dairy Products", UnitPrice = 34.0000M, UnitsInStock = 19 },
                    new Product { ProductID = 61, ProductName = "Sirop d'érable", Category = "Condiments", UnitPrice = 28.5000M, UnitsInStock = 113 },
                    new Product { ProductID = 62, ProductName = "Tarte au sucre", Category = "Confections", UnitPrice = 49.3000M, UnitsInStock = 17 },
                    new Product { ProductID = 63, ProductName = "Vegie-spread", Category = "Condiments", UnitPrice = 43.9000M, UnitsInStock = 24 },
                    new Product { ProductID = 64, ProductName = "Wimmers gute Semmelknödel", Category = "Grains/Cereals", UnitPrice = 33.2500M, UnitsInStock = 22 },
                    new Product { ProductID = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", Category = "Condiments", UnitPrice = 21.0500M, UnitsInStock = 76 },
                    new Product { ProductID = 66, ProductName = "Louisiana Hot Spiced Okra", Category = "Condiments", UnitPrice = 17.0000M, UnitsInStock = 4 },
                    new Product { ProductID = 67, ProductName = "Laughing Lumberjack Lager", Category = "Beverages", UnitPrice = 14.0000M, UnitsInStock = 52 },
                    new Product { ProductID = 68, ProductName = "Scottish Longbreads", Category = "Confections", UnitPrice = 12.5000M, UnitsInStock = 6 },
                    new Product { ProductID = 69, ProductName = "Gudbrandsdalsost", Category = "Dairy Products", UnitPrice = 36.0000M, UnitsInStock = 26 },
                    new Product { ProductID = 70, ProductName = "Outback Lager", Category = "Beverages", UnitPrice = 15.0000M, UnitsInStock = 15 },
                    new Product { ProductID = 71, ProductName = "Flotemysost", Category = "Dairy Products", UnitPrice = 21.5000M, UnitsInStock = 26 },
                    new Product { ProductID = 72, ProductName = "Mozzarella di Giovanni", Category = "Dairy Products", UnitPrice = 34.8000M, UnitsInStock = 14 },
                    new Product { ProductID = 73, ProductName = "Röd Kaviar", Category = "Seafood", UnitPrice = 15.0000M, UnitsInStock = 101 },
                    new Product { ProductID = 74, ProductName = "Longlife Tofu", Category = "Produce", UnitPrice = 10.0000M, UnitsInStock = 4 },
                    new Product { ProductID = 75, ProductName = "Rhönbräu Klosterbier", Category = "Beverages", UnitPrice = 7.7500M, UnitsInStock = 125 },
                    new Product { ProductID = 76, ProductName = "Lakkalikööri", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 57 },
                    new Product { ProductID = 77, ProductName = "Original Frankfurter grüne Soße", Category = "Condiments", UnitPrice = 13.0000M, UnitsInStock = 32 }
                };

                // Customer/Order data read into memory from XML file using XLinq:
                customerList = (
                    from e in XDocument.Load("Customers.xml").
                              Root.Elements("customer")
                    select new Customer
                    {
                        CustomerID = (string)e.Element("id"),
                        CompanyName = (string)e.Element("name"),
                        Address = (string)e.Element("address"),
                        City = (string)e.Element("city"),
                        Region = (string)e.Element("region"),
                        PostalCode = (string)e.Element("postalcode"),
                        Country = (string)e.Element("country"),
                        Phone = (string)e.Element("phone"),
                        Fax = (string)e.Element("fax"),
                        Orders = (
                            from o in e.Elements("orders").Elements("order")
                            select new Order
                            {
                                OrderID = (int)o.Element("id"),
                                OrderDate = (DateTime)o.Element("orderdate"),
                                Total = (decimal)o.Element("total")
                            })
                            .ToArray()
                    })
                    .ToList();
            }
        }
    }
}
