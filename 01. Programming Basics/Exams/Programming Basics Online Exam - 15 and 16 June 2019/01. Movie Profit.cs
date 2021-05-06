namespace _01.MovieProfit
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string title = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int theaterInterest = int.Parse(Console.ReadLine());

            double profit = ProfitFromTheMovie(days, tickets, ticketPrice, theaterInterest);

            Print(title, profit);
        }

        private static void Print(string title, double profit)
        {
            Console.WriteLine($"The profit from the movie {title} is {profit:F2} lv.");
        }

        private static double ProfitFromTheMovie(int days, int tickets, double ticketPrice, int theaterInterest)
        {
            double dayIncome = tickets * ticketPrice;
            double totalIncome = dayIncome * days;
            
            double theaterProfit = totalIncome * ((double)theaterInterest / 100);

            double profit = totalIncome - theaterProfit;
            return profit;
        }
    }
}
