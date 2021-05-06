using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string  Name { get; set; }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }//– adds an gladiator to the arena.
        public void Remove(string name)
        {
            var gladiator = gladiators.First(g => g.Name == name);
            gladiators.Remove(gladiator);
        }//– removes an gladiator by given name.

        public Gladiator GetGladitorWithHighestStatPower()
        {
            var gladiator = gladiators.OrderByDescending(g => g.GetStatPower()).First();
            return gladiator;
        }//– returns the Gladiator which has the highest stat.

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var gladiator = gladiators.OrderByDescending(g => g.GetWeaponPower()).First();
            return gladiator;
        }//– returns the Gladiator which poses the weapon with the highest power.

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var gladiator = gladiators.OrderByDescending(g => g.GetTotalPower()).First();
            return gladiator;
        }//– returns the Gladiator which has the highest total power.
        public  int Count => gladiators.Count;//– returns the number of stored heroes.

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
