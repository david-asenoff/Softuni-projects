using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    sealed class Truck:Vehicle
    {
        private const double AirconditionerFuelDrain = 1.6;
        public Truck (double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption += AirconditionerFuelDrain)
        {
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += 0.95 * liters;
        }
    }
}
