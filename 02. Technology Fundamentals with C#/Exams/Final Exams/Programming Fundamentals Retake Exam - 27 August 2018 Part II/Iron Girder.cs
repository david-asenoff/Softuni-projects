using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Iron_Girder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> times = new Dictionary<string, int>();
            Dictionary<string, int> people = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Slide rule")
                {
                    break;
                }

                List<string> inputInfo = input.Split(':').ToList();

                string name = inputInfo[0];

                List<string> commandInfo = inputInfo[1].Split("->").ToList();

                string type = commandInfo[0];
                int passengersCount = int.Parse(commandInfo[1]);

                if(type == "ambush")
                {
                    if (people.ContainsKey(name))
                    {
                        people[name] -= passengersCount;
                    }

                    if (times.ContainsKey(name))
                    {
                        times[name] = 0;
                    }
                }
                else
                {
                    int time = int.Parse(type);

                    if (people.ContainsKey(name))
                    {
                        people[name] += passengersCount;
                    }
                    else
                    {
                        people.Add(name, passengersCount);
                    }

                    if (times.ContainsKey(name))
                    {
                        if(times[name] > time)
                        {
                            times[name] = time;
                        }
                        else if(times[name] == 0)
                        {
                            times[name] = time;
                        }
                    }
                    else
                    {
                        times.Add(name, time);
                    }
                }
            }

            var orderedList = times.OrderBy(x => x.Value).ThenBy(x => x.Key);

            foreach(var town in orderedList)
            {              
                string name = town.Key;
                int time = town.Value;
                int peopleCount = people[name];

                if (peopleCount > 0 && time > 0)
                {
                    Console.WriteLine($"{name} -> Time: {time} -> Passengers: {peopleCount}");
                }
            }
        }
    }
}
