using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> charCode = Console.ReadLine().Split(':').Select(int.Parse).ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < charCode.Count; i++)
            {
                sb.Append((char)charCode[i]);
            }

            string code = sb.ToString();

            List<string> emojis = new List<string>();

            int totalPower = 0;

            string pattern = @"(?<=[\s])(?<emoji>:[a-z]{4,}:)(?=[\s,.!?])";

            MatchCollection matches = Regex.Matches(text, pattern);

            bool isSame = false;

            foreach(Match match in matches)
            {
                string emoji = match.Groups["emoji"].Value;

                int currentPower = 0;

                for (int i = 1; i < emoji.Length-1; i++)
                {
                    currentPower += emoji[i];
                }

                if(emoji == ":"+code+":")
                {
                    isSame = true;
                }

                totalPower += currentPower;
                emojis.Add(emoji);
            }

            if(isSame == true)
            {
                totalPower *= 2;
            }

            if (emojis.Count > 0)
            {
                Console.Write($"Emojis found: {string.Join(", ", emojis)}");

                Console.WriteLine();
            }

            Console.WriteLine($"Total Emoji Power: {totalPower}");
        }
    }
}
