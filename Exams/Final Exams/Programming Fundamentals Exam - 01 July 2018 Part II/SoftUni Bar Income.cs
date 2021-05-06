using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = 0;
            string pattern = @"[\%](?<customer>[A-Z][a-z]+)[\%][^\|\%\.\$]*[\<](?<product>[\w]+)[\>][^\|\%\.\$]*[\|](?<count>[0-9]+)[\|][^\|\%\.\$]*?(?<price>[0-9]+[\.]{0,1}[0-9]+)[\$]";

            while (true)
            {
                string order = Console.ReadLine();

                if(order == "end of shift")
                {
                    Console.WriteLine($"Total income: {income:F2}");
                    break;
                }

                if(Regex.IsMatch(order, pattern))
                {
                    Match match = Regex.Match(order, pattern);
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double currentIncome = count * price;
                    income += currentIncome;

                    Console.WriteLine($"{customer}: { product} - {currentIncome:F2}");
                }
            }
        }
    }
}
