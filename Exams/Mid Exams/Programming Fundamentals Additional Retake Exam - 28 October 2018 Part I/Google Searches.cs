using System;

namespace _01._Google_Searches
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalDays = int.Parse(Console.ReadLine());
            int numberUsers = int.Parse(Console.ReadLine());
            double moneyFromUser = double.Parse(Console.ReadLine());
            double moneyForDay = 0;
            double moneyForUser = 0;

            for (int i = 1; i <= numberUsers; i++)
            {
                int numberWords = int.Parse(Console.ReadLine());

                if (numberWords > 5)
                {
                    continue;
                }
                else if(numberWords == 1)
                {
                    moneyForUser += moneyFromUser * 2;
                }
                else
                {
                    moneyForUser += moneyFromUser;
                }

                if (i % 3 == 0)
                {
                    moneyForUser *= 3;
                }

                moneyForDay += moneyForUser;
                moneyForUser = 0;
            }

            double totalMoney = moneyForDay * totalDays;

            Console.WriteLine($"Total money earned for {totalDays} days: {totalMoney:F2}");
        }
    }
}
