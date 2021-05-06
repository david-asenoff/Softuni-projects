namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();
            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] inputParts = Console.ReadLine()?
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputParts != null)
                {
                    Engine.Initialization(engines,inputParts);
                }
            }

            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputParts = Console.ReadLine()?
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputParts != null)
                {
                    string model = inputParts[0];
                    string engineModel = inputParts[1];
                    Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);
                    Car car = new Car(model, engine);

                    Car.Initialization(inputParts, engineModel, engine, car, cars);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}