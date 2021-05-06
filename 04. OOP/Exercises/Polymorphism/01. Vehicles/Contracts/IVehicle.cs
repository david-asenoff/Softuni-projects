using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace P01.Vehicles.Contracts
{
    interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        string Drive(double distance);
        void Refuel(double liters);
    }
}
