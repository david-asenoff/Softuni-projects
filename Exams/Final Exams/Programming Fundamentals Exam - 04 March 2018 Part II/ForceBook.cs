using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            Dictionary<string, int> sides = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.IndexOf('|') >= 0)
                {
                    List<string> commandInfo = command.Split(" | ").ToList();

                    string side = commandInfo[0];

                    string user = commandInfo[1];

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, side);

                        if (sides.ContainsKey(side))
                        {
                            sides[side]++;
                        }
                        else
                        {
                            sides.Add(side, 1);
                        }
                    }
                }
                else if (command.IndexOf(" -> ") >= 0)
                {
                    List<string> commandInfo = command.Split(" -> ").ToList();

                    string side = commandInfo[1];

                    string user = commandInfo[0];

                    if (users.ContainsKey(user))
                    {
                        string oldSide = users[user];

                        users[user] = side;

                        if (sides.ContainsKey(oldSide))
                        {
                            sides[oldSide]--;
                        }

                        if (sides.ContainsKey(side))
                        {
                            sides[side]++;
                        }
                        else
                        {
                            sides.Add(side, 1);
                        }
                    }
                    else
                    {
                        users.Add(user, side);

                        if (sides.ContainsKey(side))
                        {
                            sides[side]++;
                        }
                        else
                        {
                            sides.Add(side, 1);
                        }
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedSides = sides.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach(var item in orderedSides)
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value}");

                var orderedUsers = users.Where(x => x.Value == item.Key).OrderBy(x => x.Key);

                foreach(var element in orderedUsers)
                {
                    Console.WriteLine($"! {element.Key}");
                }
            }
        }
    }
}
