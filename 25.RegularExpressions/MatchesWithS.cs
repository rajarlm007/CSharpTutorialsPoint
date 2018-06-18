using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _25.RegularExpressions
{
    class MatchesWithS
    {
        /*
        1   public bool IsMatch(string input)   
        -Indicates whether the regular expression specified in the Regex constructor finds a match in a specified input string.

        2   public bool IsMatch(string input, int startat)
        -Indicates whether the regular expression specified in the Regex constructor finds a match in the specified input string, beginning at the specified starting position in the string.

        3	public static bool IsMatch(string input, string pattern)
        -Indicates whether the specified regular expression finds a match in the specified input string.

        4	public MatchCollection Matches(string input)
        -Searches the specified input string for all occurrences of a regular expression 
        */

        internal static void showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            MatchCollection mc = Regex.Matches(text, expr);

            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }
    }
}
