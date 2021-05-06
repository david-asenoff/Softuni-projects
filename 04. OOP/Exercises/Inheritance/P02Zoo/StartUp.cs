using System;
using Zoo.Reptiles;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake cobra = new Snake("Sisi");

            Console.WriteLine($"The name of my cobra snake is {cobra.Name}");
        }
    }
}
