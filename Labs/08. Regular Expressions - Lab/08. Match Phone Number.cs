using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"([+][3][5][9])([- ])([2])\2([0-9]{3})\2([0-9]{4})\b";
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, regex);

            List<string> phones = new List<string>();

            foreach (Match match in matches)
            {
                phones.Add(match.Value);
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
