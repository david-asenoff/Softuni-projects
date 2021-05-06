using System;

namespace P03.Ferrari
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            string driversName = Console.ReadLine();
            Ferrari myCar = new Ferrari(driversName);
            Console.WriteLine(myCar);
        }
    }
}
