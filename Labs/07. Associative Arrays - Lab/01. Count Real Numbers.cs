using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Dictionary<double, int> orderedList = new Dictionary<double, int>();

            foreach(int number in numbers)
            {
                if (orderedList.ContainsKey(number))
                {
                    orderedList[number]++;
                }
                else
                {
                    orderedList.Add(number, 1);
                }
            }

            foreach(var num in orderedList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
