using System;
using System.Text.RegularExpressions;

namespace _07._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            string regex = @"\b(?<day>[0-9]{2})([./-])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b";

            MatchCollection matches = Regex.Matches(text, regex);

            foreach(Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            }
        }
    }
}
