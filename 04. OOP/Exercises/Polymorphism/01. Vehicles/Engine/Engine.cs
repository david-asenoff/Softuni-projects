using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using P01.Vehicles.Models;

namespace P01.Vehicles.Engine
{
    public class Engine
    {
        private Vehicle car = null;
        private Vehicle truck = null;
        public void Run()
        {
            Initialization();
            ReadCommands();
            Print();

        }

        private void Print()
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private void ReadCommands()
        {
            int commandsCount = int.Parse(Console.ReadLine());
            for (int command = 0; command < commandsCount; command++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string vehicleCommand = inputArgs[0];
                string vehicleType = inputArgs[1];

                if (vehicleCommand== "Drive")
                {
                    double distance = double.Parse(inputArgs[2]);

                    if (vehicleType=="Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType=="Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (vehicleCommand== "Refuel")
                {
                    double litters = double.Parse(inputArgs[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(litters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(litters);
                    }
                }
            }
        }

        private void Initialization()
        {
            var tuple = ReadData();
            car = new Car(tuple.Item1, tuple.Item2);

            var tuple2 = ReadData();
            truck = new Truck(tuple2.Item1, tuple2.Item2);
        }

        private static Tuple<double, double> ReadData()
        {
        string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);

            var tuple = new Tuple<double, double>(fuelQuantity, fuelConsumption);
            return tuple;
        }
    }
}
