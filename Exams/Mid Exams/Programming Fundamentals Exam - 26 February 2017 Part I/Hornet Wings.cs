using System;

namespace _01._Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            double totalDistance = wingFlaps / 1000 * distance;
            int seconds = wingFlaps / endurance * 5 + wingFlaps / 100;

            Console.WriteLine($"{totalDistance:F2} m.");
            Console.WriteLine($"{seconds} s.");
        }
    }
}
