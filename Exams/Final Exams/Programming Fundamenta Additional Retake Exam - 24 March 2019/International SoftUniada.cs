using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._International_SoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> countries = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "END")
                {
                    break;
                }

                List<string> inputInfo = input.Split(" -> ").ToList();

                string country = inputInfo[0];

                string name = inputInfo[1];

                int points = int.Parse(inputInfo[2]);

                if (countries.ContainsKey(country))
                {
                    if (countries[country].ContainsKey(name))
                    {
                        countries[country][name] += points;
                    }
                    else
                    {
                        countries[country].Add(name, points);
                    }
                }
                else
                {
                    Dictionary<string, int> current = new Dictionary<string, int>();

                    current.Add(name, points);

                    countries.Add(country, current);
                }
            }

            var orderedCountries = countries.OrderByDescending(x => x.Value.Sum(a => a.Value));

            foreach(var kvp in orderedCountries)
            {
                int totalPoints = kvp.Value.Sum(a => a.Value);

                Console.WriteLine($"{kvp.Key}: {totalPoints}");

                foreach(var item in kvp.Value)
                {
                    Console.WriteLine($"-- {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
