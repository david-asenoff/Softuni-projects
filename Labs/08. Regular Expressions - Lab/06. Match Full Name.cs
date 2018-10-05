using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matches = Regex.Matches(text, regex);

            foreach(Match match in matches)
            {
                Console.Write(match.Value + ' ');
            }
        }
    }
}
