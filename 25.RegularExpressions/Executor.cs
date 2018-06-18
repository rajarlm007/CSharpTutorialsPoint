using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _25.RegularExpressions
{
    class Executor
    {
        static void Main(string[] args)
        {
            // find matches with S
            string str = "A Thousand Splendid Suns";
            Console.WriteLine("Matching words that start with 'S': ");
            MatchesWithM_e.showMatch(str, @"\bS\S*");

            // find matches with starting m and ending e
            string str2 = "make maze and manage to measure it";
            Console.WriteLine("Matching words start with 'm' and ends with 'e':");
            MatchesWithS.showMatch(str2, @"\bm\S*e\b");

            // ReplaceWhiteSpace
            string input = "Hello   World   ";
            string pattern = "\\s+";
            string replacement = " ";

            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);

            Console.WriteLine("Original String: {0}", input);
            Console.WriteLine("Replacement String: {0}", result);

            Console.ReadKey();
        }
    }
}
