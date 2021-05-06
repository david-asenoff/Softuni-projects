using System;
using System.Collections.Generic;
using System.Text;
using P01.Vehicles.Contracts;

namespace P01.Vehicles.Models
{
    sealed class Car : Vehicle
    {
        private const double AirconditionerFuelDrain = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption += AirconditionerFuelDrain)
        {
        }
    }
}
