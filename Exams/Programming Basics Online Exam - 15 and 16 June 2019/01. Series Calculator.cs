namespace _01.SeriesCalculator
{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            string title = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodesCount = int.Parse(Console.ReadLine());
            int episodeMinutes = int.Parse(Console.ReadLine());
            
            double totalMinutes = TotalMinutes(seasons,episodesCount,episodeMinutes);

            Print(title, totalMinutes);

        }

        private static void Print(string title, double episodesTotalMinutes)
        {
            Console.WriteLine($"Total time needed to watch the {title} series is {Math.Floor(episodesTotalMinutes)} minutes.");
        }

        private static double TotalMinutes(int seasons, int episodesCount, int episodeMinutes)
        {
            double episodeMinutesWithAdds = episodeMinutes * 1.2;
            int specialEpisodesMin = seasons * 10;
            double totalMinutes = episodeMinutesWithAdds * seasons * episodesCount + specialEpisodesMin;
            return totalMinutes;
        }
    }
}

