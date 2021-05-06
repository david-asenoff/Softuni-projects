using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());

            int days = int.Parse(Console.ReadLine());

            int totalMoney = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 15 == 0)
                {
                    partySize += 5;
                }

                if (i % 10 == 0)
                {
                    partySize -= 2;
                }

                if (i % 5 == 0)
                {
                    totalMoney += partySize * 20;

                    if (i % 3 == 0)
                    {
                        totalMoney -= partySize * 2;
                    }
                }

                if (i % 3 == 0)
                {
                    totalMoney -= partySize * 3;
                }

                totalMoney += 50;
                totalMoney -= partySize * 2;
            }

                Console.WriteLine($"{partySize} companions received {totalMoney / partySize} coins each.");
        }
    }
}
