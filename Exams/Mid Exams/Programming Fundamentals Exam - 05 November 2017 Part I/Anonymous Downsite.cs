using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01._Anonymous_Downsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWebsidesDown = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            BigInteger token = new BigInteger();
            token = 1;

            for (int i = 0; i < numberWebsidesDown; i++)
            {
                string input = Console.ReadLine();

                List<string> inputInfo = input.Split(' ').ToList();

                string siteName = inputInfo[0];
                long visits = long.Parse(inputInfo[1]);
                decimal pricePerVisit = decimal.Parse(inputInfo[2]);
                decimal siteLoss = visits * pricePerVisit;
                token *= securityKey;

                Console.WriteLine(siteName);

                totalLoss += siteLoss;
            }

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {token}");
        }
    }
}
