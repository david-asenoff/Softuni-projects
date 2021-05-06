using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sumTotalRemoved = 0;

            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                int numberForCorrection = 0;

                if (number < 0)
                {
                    numberForCorrection = distances[0];
                    distances[0] = distances[distances.Count - 1];

                }
                else if (number >= 0 && number < distances.Count)
                {
                    numberForCorrection = distances[number];

                    distances.RemoveAt(number);
                }
                else if (number >= distances.Count)
                {
                    numberForCorrection = distances[distances.Count - 1];
                    distances.RemoveAt(distances.Count - 1);
                    distances.Add(distances[0]);
                }
              

                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= numberForCorrection)
                    {
                        distances[i] += numberForCorrection;
                    }
                    else
                    {
                        distances[i] -= numberForCorrection;
                    }
                }

                sumTotalRemoved += numberForCorrection;

                if(distances.Count <= 0)
                {
                    break;
                }
            }

            Console.WriteLine(sumTotalRemoved);
        }
    }
}
