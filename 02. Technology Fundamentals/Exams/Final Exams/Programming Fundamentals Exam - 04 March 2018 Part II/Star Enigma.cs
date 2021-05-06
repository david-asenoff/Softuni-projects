using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            int numberLines = int.Parse(Console.ReadLine());
            string pattern = @"[^\@\-\!\:\>]*\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>[0-9]+)[^\@\-\!\:\>]*\!(?<type>[AD]{1})\![^\@\-\!\:\>]*\-\>(?<count>[0-9]+)[^\@\-\!\:\>]*";

            for (int i = 0; i < numberLines; i++)
            {
                string message = Console.ReadLine();

                int countLetters = 0;

                foreach(char ch in message.ToLower())
                {
                    if(ch == 's' || ch == 't' || ch == 'a' || ch == 'r')
                    {
                        countLetters++;
                    }
                }

                StringBuilder sb = new StringBuilder();

                foreach(char letter in message)
                {
                    sb.Append((char)(letter - countLetters));
                }

                string decryptedMessage = sb.ToString();

                if (Regex.IsMatch(decryptedMessage, pattern))
                {
                    Match match = Regex.Match(decryptedMessage, pattern);

                    string name = match.Groups["name"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string type = match.Groups["type"].Value;
                    int count = int.Parse(match.Groups["count"].Value);

                    if(type == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else if(type == "D")
                    {
                        destroyedPlanets.Add(name);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: { attackedPlanets.Count}");

            attackedPlanets.Sort();

            foreach(string name in attackedPlanets)
            {
                Console.WriteLine($"-> {name}");
            }

            destroyedPlanets.Sort();

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (string name in destroyedPlanets)
            {
                Console.WriteLine($"-> {name}");
            }
        }
    }
}
