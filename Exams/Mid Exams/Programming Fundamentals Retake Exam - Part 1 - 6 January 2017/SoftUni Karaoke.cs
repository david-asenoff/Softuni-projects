using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            List<string> songs = Console.ReadLine().Split(", ").ToList();
            List<List<string>> players = new List<List<string>>();

            for (int i = 0; i < names.Count; i++)
            {
                List<string> newList = new List<string>();
                newList.Add(names[i]);
                players.Add(newList);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "dawn")
                {
                    break;
                }

                List<string> inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = inputInfo[0];
                string song = inputInfo[1];
                string award = inputInfo[2];

                if (names.IndexOf(name) >= 0 && songs.IndexOf(song) >= 0)
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        if(players[i][0] == name && players[i].IndexOf(award) < 0)
                        {
                            players[i].Add(award);
                        }
                    }
                }
            }

            var orderedList = players.OrderByDescending(order => order.Count).Where(x => x.Count>1).ToList();

            for (int a = 0; a < orderedList.Count; a++)
            {
                Console.WriteLine($"{orderedList[a][0]}: {orderedList[a].Count - 1} awards");

                for (int b = 1; b < orderedList[a].Count; b++)
                {
                    Console.WriteLine($"--{orderedList[a][b]}");
                }
            }

            if (orderedList.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
