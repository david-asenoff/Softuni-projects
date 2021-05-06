using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        List<Astronaut> data;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public SpaceStation(string name, int capacity)
        {
            data = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public void Add(Astronaut astronaut)
        {
            if (data.Count<Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            foreach (var astronaut in data)
            {
                if (astronaut.Name==name)
                {
                    return true;
                }
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldest = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut ourGuy = data.Where(x=>x.Name==name).FirstOrDefault();
            return ourGuy;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                sb.AppendLine($"{astronaut}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
