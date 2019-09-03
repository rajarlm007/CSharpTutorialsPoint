using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLamba
{
    public class GroupingOperators
    {

        public static void Exec()
        {
            LinqSamples samples = new LinqSamples();
            samples.DataSetLinq40();
            samples.DataSetLinq41();
            samples.DataSetLinq42();
            samples.DataSetLinq43();
            samples.DataSetLinq44();
            samples.DataSetLinq45();
        }


        private class LinqSamples
        {
            private readonly DataSet testDS;

            public LinqSamples()
            {
                testDS = LinqDataTable.TestHelper.CreateTestDataset();
            }



            public void DataSetLinq40()
            {

                var numbers = testDS.Tables["Numbers"].AsEnumerable();

                var numberGroups = numbers.GroupBy(n => n.Field<int>("number") % 5).Select(g => new { Remainder = g.Key, Numbers = g });

                foreach (var g in numberGroups)
                {
                    Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                    foreach (var n in g.Numbers)
                    {
                        Console.WriteLine(n.Field<int>("number"));
                    }
                }
            }
            public void DataSetLinq41()
            {

                var words4 = testDS.Tables["Words4"].AsEnumerable();

                var wordGroups = words4.GroupBy(w => w.Field<string>("word")[0]).Select(g => new { FirstLetter = g.Key, Words = g });

                foreach (var g in wordGroups)
                {
                    Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
                    foreach (var w in g.Words)
                    {
                        Console.WriteLine(w.Field<string>("word"));
                    }
                }
            }
            public void DataSetLinq42()
            {

                var products = testDS.Tables["Products"].AsEnumerable();

                var productGroups = products.GroupBy(p => p.Field<string>("Category")).Select(g => new { Category = g.Key, Products = g });

                foreach (var g in productGroups)
                {
                    Console.WriteLine("Category: {0}", g.Category);
                    foreach (var w in g.Products)
                    {
                        Console.WriteLine("\t" + w.Field<string>("ProductName"));
                    }
                }
            }
            public void DataSetLinq43()
            {

                var customers = testDS.Tables["Customers"].AsEnumerable();

                var customerOrderGroups =
                    customers.Select(c => new {
                        CompanyName = c.Field<string>("CompanyName"),
                        YearGroups = c.GetChildRows("CustomersOrders").
                            GroupBy(o => o.Field<DateTime>("OrderDate").Year).
                            Select(yg => new {
                                Year = yg.Key,
                                MonthGroups = yg.GroupBy(o => o.Field<DateTime>("OrderDate").Month).
                                Select(mg => new {
                                    Month = mg.Key,
                                    Orders = mg
                                })
                            })
                    });

                foreach (var cog in customerOrderGroups)
                {
                    Console.WriteLine("CompanyName= {0}", cog.CompanyName);
                    foreach (var yg in cog.YearGroups)
                    {
                        Console.WriteLine("\t Year= {0}", yg.Year);
                        foreach (var mg in yg.MonthGroups)
                        {
                            Console.WriteLine("\t\t Month= {0}", mg.Month);
                            foreach (var order in mg.Orders)
                            {
                                Console.WriteLine("\t\t\t OrderID= {0} ", order.Field<int>("OrderID"));
                                Console.WriteLine("\t\t\t OrderDate= {0} ", order.Field<DateTime>("OrderDate"));
                            }
                        }
                    }
                }
            }

            public void DataSetLinq44()
            {

                var anagrams = testDS.Tables["Anagrams"].AsEnumerable();

                var orderGroups = anagrams.GroupBy(w => w.Field<string>("anagram").Trim());

                foreach (var g in orderGroups)
                {
                    Console.WriteLine("Key: {0}", g.Key);
                    foreach (var w in g)
                    {
                        Console.WriteLine("\t" + w.Field<string>("anagram"));
                    }
                }
            }
            public void DataSetLinq45()
            {

                var anagrams = testDS.Tables["Anagrams"].AsEnumerable();

                var orderGroups = anagrams.GroupBy(
                    w => w.Field<string>("anagram").Trim(),
                    a => a.Field<string>("anagram").ToUpper()
                    
                    );

                foreach (var g in orderGroups)
                {
                    Console.WriteLine("Key: {0}", g.Key);
                    foreach (var w in g)
                    {
                        Console.WriteLine("\t" + w);
                    }
                }
            }



        }
    }
}
