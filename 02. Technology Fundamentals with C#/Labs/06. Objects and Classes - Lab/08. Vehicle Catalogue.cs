using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog(new List<Car>(), new List<Truck>());

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end")
                {
                    break;
                }

                List<string> inputInformation = input.Split('/').ToList();

                if(inputInformation[0] == "Car")
                {
                    string brand = inputInformation[1];
                    string model = inputInformation[2];
                    int power = int.Parse(inputInformation[3]);

                    Car newCar = new Car(brand, model, power);

                    catalog.Cars.Add(newCar);
                }
                else if (inputInformation[0] == "Truck")
                {
                    string brand = inputInformation[1];
                    string model = inputInformation[2];
                    double weight = double.Parse(inputInformation[3]);

                    Truck newTruck = new Truck(brand, model, weight);

                    catalog.Trucks.Add(newTruck);
                }
            }

            List<Car> orderedCars = catalog.Cars.OrderBy(order => order.Brand).ToList();
            List<Truck> orderedTrucks = catalog.Trucks.OrderBy(order => order.Brand).ToList();


            if (orderedCars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (orderedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach(Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public Car(string brand, string model, int power)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = power;
        }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }

        public Catalog(List<Car> listCars, List<Truck> listTrucks)
        {
            this.Cars = listCars;
            this.Trucks = listTrucks;
        }

    }

    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public double Weight { get; set; }

        public Truck(string brand, string model, double weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
    }
}
