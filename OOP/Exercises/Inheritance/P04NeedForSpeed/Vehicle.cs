using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        private int horsePower;
        private double fuel;

        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption
            => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            double neededFuel = FuelConsumption * kilometers;

            if (neededFuel<=this.Fuel)
            {
                this.Fuel -= neededFuel;
            }

        }
    }
}
