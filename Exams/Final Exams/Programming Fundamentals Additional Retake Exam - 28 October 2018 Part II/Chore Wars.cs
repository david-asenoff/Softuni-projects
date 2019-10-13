using System;
using System.Text.RegularExpressions;

namespace _03._Chore_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternDishes = @"(\<(?<dishes>[a-z0-9]+)\>)+";
            string patternHouse = @"(\[(?<house>[A-Z0-9]+)\])+";
            string patternLaundry = @"(\{(?<laundry>[^\}]+)\})+";
            int sumDishes = 0;
            int sumHouse = 0;
            int sumLoundry = 0;

            while (true)
            {
                string message = Console.ReadLine();

                if (message == "wife is happy")
                {
                    break;
                }

                if (Regex.IsMatch(message, patternDishes))
                {
                    MatchCollection matches = Regex.Matches(message, patternDishes);

                    string text = string.Empty;

                    foreach(Match match in matches)
                    {
                        text = match.Groups["dishes"].Value;
                        
                        foreach(char ch in text)
                        {
                            if (Char.IsDigit(ch))
                            {
                                sumDishes += ch - '0';
                            }
                        }
                    }                   
                }
                else if (Regex.IsMatch(message, patternLaundry))
                {
                    MatchCollection matches = Regex.Matches(message, patternLaundry);

                    string text = string.Empty;

                    foreach (Match match in matches)
                    {
                        text = match.Groups["laundry"].Value;

                        foreach (char ch in text)
                        {
                            if (Char.IsDigit(ch))
                            {
                                sumLoundry += ch - '0';
                            }
                        }
                    }
                }
                else if (Regex.IsMatch(message, patternHouse))
                {
                    MatchCollection matches = Regex.Matches(message, patternHouse);

                    string text = string.Empty;

                    foreach (Match match in matches)
                    {
                        text = match.Groups["house"].Value;

                        foreach (char ch in text)
                        {
                            if (Char.IsDigit(ch))
                            {
                                sumHouse += ch - '0';
                            }
                        }
                    }
                }
            }


            int totalMinutes = sumLoundry + sumHouse + sumDishes;
            Console.WriteLine($"Doing the dishes - {sumDishes} min.");
            Console.WriteLine($"Cleaning the house - {sumHouse} min.");
            Console.WriteLine($"Doing the laundry - {sumLoundry} min.");
            Console.WriteLine($"Total - {totalMinutes} min.");
        }
    }
}
