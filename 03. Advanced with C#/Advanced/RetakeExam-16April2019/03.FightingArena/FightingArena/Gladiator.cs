using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }
        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon{ get; set; }

        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }// return the sum of the stat properties plus the sum of the weapon properties.

        public int GetWeaponPower()
        {
            int weaponPower = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
            return weaponPower;
        }//: int - return the sum of the weapon properties.

        public int GetStatPower()
        {
            int statSum = this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength;
            return statSum;
        }//: int - return the sum of the stat properties.

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]")
                .AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]")
                .AppendLine($"  Stat Power: [{this.GetStatPower()}]");
            return sb.ToString().TrimEnd();
        }
    }
}
