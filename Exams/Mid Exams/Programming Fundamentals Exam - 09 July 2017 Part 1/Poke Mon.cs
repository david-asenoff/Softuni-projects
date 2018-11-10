using System;

namespace _01._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            double halfPower = power / 2;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int target = 0;

            while (true)
            {
                if(power == halfPower && exhaustionFactor != 0)
                {
                    power = power/exhaustionFactor;
                }

                if (power < distance)
                {
                    break;
                }

                power -= distance;
                target++;
            }

            Console.WriteLine(power);
            Console.WriteLine(target);
        }
    }
}
