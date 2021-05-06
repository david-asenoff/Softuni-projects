using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Ferrari
{
    public class Ferrari:ICar,IFerrari
    {
        public string Gas => "Gas!";
        public string Brake => "Brakes!";
        public string Model => "488-Spider";
        public string DriversName { get; }

        public Ferrari(string driversName)
        {
            DriversName = driversName;
        }

        public override string ToString()
        {
            return $"488-Spider/Brakes!/Gas!/{this.DriversName}";
        }
    }
}
