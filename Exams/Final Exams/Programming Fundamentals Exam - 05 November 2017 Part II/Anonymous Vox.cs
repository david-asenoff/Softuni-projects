using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string valuesInput = Console.ReadLine();

            string patternValue = @"\{(?<value>[^\{\}]*)\}";

            string patternText = @"(?<start>[A-Za-z]+)(?<placeholder>.+)(?<end>\1)";

            MatchCollection matchValues = Regex.Matches(valuesInput, patternValue);

            MatchCollection matchText = Regex.Matches(text, patternText);


            for (int i = 0; i < Math.Min(matchText.Count, matchValues.Count); i++)
            {
                string placeholder = matchText[i].Groups["placeholder"].Value;

                string value = matchValues[i].Groups["value"].Value;

                int startIndex = text.IndexOf(placeholder);

                text = text.Substring(0, startIndex) + value + text.Substring(startIndex + placeholder.Length);
            }

            Console.WriteLine(text);

        }
    }
}
