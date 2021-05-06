using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split('|').ToList();

            int health = 100;
            int coins = 0;

            for (int i = 0; i < rooms.Count; i++)
            {
                List<string> roomInfo = rooms[i].Split(' ').ToList();

                string command = roomInfo[0];
                int number = int.Parse(roomInfo[1]);

                if (number >= 0)
                {
                    if (command == "potion")
                    {
                        int healthNumber = int.Parse(roomInfo[1]);

                        if (healthNumber + health > 100)
                        {
                            healthNumber = 100 - health;
                        }

                        health += healthNumber;

                        Console.WriteLine($"You healed for {healthNumber} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (command == "chest")
                    {
                        int foundCoins = int.Parse(roomInfo[1]);

                        coins += foundCoins;

                        Console.WriteLine($"You found {foundCoins} coins.");
                    }
                    else
                    {
                        int attackNumber = int.Parse(roomInfo[1]);

                        health -= attackNumber;

                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else 
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {i+1}");
                            break;
                        }
                    }                           
                }
            }

            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: { coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
