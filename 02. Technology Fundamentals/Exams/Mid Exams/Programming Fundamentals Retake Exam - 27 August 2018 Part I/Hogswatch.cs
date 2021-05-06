using System;
using System.Collections.Generic;

namespace _01._Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberHouses = int.Parse(Console.ReadLine());
            int numberPresents = int.Parse(Console.ReadLine());
            List<int> houses = new List<int>();
            int numberCourses = 0;
            int additionPresents = 0;
            int leftPresents = numberPresents;

            for (int i = 0; i < numberHouses; i++)
            {
                int numberChildren = int.Parse(Console.ReadLine());
                houses.Add(numberChildren);
            }

            for (int i = 0; i < houses.Count; i++)
            {
                if(leftPresents >= houses[i])
                {
                    leftPresents -= houses[i];
                }
                else
                {
                    int presentsToGet = numberPresents / (i + 1) * (houses.Count - i - 1) + (houses[i] - leftPresents);
                    additionPresents += presentsToGet;
                    leftPresents += presentsToGet;
                    leftPresents -= houses[i];
                    numberCourses++;
                }
            }

            if(numberCourses == 0 && numberPresents >= 0)
            {
                Console.WriteLine($"{leftPresents}");
            }
            else
            {
                Console.WriteLine($"{numberCourses}");
                Console.WriteLine($"{additionPresents}");
            }
        }
    }
}
