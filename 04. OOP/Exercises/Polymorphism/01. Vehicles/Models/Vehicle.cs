using System;
using System.Collections.Generic;
using System.Text;
using P01.Vehicles.Contracts;

namespace P01.Vehicles.Models
{
    abstract class Vehicle : IVehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; private set; }
        public string Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;
            if (FuelQuantity < neededFuel)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}