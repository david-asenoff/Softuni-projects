using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputInfo = Console.ReadLine().Split('|').ToList();
 
            string firstPart = inputInfo[0];
            string secondPart = inputInfo[1];
            string thirdPart = inputInfo[2];
            List<string> words = thirdPart.Split().ToList();

            string patternFirstPart = @"([\#\$\%\*\&])(?<capitalLetters>[A-Z]+)(\1)";

            Match matchFirst = Regex.Match(firstPart, patternFirstPart);
            string matchCapitals = matchFirst.Groups["capitalLetters"].Value;

            for (int i = 0; i <matchCapitals.Length; i++)
            {
                char currentChar = matchCapitals[i];
                int asciCode = currentChar;

                string patternSecond = $@"({asciCode})" + @"[\:](?<length>[0-9]{2})";
                Match matchSecond = Regex.Match(secondPart, patternSecond);
                int length = int.Parse(matchSecond.Groups["length"].Value);

                string patternThird = $@"(?<=\s|^){currentChar}[^\s]{{{length}}}(?=\s|$)";

                Match thirdMatch = Regex.Match(thirdPart, patternThird);

                string word = thirdMatch.ToString();

                Console.WriteLine(word);
            }
        }
    }
}
