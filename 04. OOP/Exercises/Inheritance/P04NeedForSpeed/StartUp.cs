using System;
using NeedForSpeed.Cars;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar mazda323F = new SportCar(200,100);
            FamilyCar daciaSandero = new FamilyCar(90,100);

            Console.WriteLine($"Mazda 323F a {mazda323F.GetType().Name} has {mazda323F.FuelConsumption} fuel consumption.");
            Console.WriteLine($"Dacia Sandero a {daciaSandero.GetType().Name} has {daciaSandero.FuelConsumption} fuel consumption.");
        }
    }
}
