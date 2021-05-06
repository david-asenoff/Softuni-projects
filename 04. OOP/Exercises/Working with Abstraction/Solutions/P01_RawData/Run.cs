
namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Run
    {
        public static List<Car> cars = new List<Car>();

        public void CarFactory()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                CreateCar(parameters, cars);
            }

            string command = Console.ReadLine();
            Print(command);
        }

        public static void Print(string command)
        {
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.TirePressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        public static void CreateCar(string[] parameters, List<Car> cars)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            var engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);

            var tire1 = new Tire(tire1Pressure, tire1age);
            var tire2 = new Tire(tire2Pressure, tire1age);
            var tire3 = new Tire(tire3Pressure, tire1age);
            var tire4 = new Tire(tire4Pressure, tire1age);

            cars.Add(new Car(model, engine, cargo, tire1, tire2, tire3, tire4));
        }

    }
}


