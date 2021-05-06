using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < number; i++)
            {
                List<string> input = Console.ReadLine().Split('_').ToList();

                Song inputSong = new Song(input[0], input[1], input[2]);

                songs.Add(inputSong);
            }

            string typeForPrint = Console.ReadLine();

            if(typeForPrint == "all")
            {
                foreach(Song so in songs)
                {
                    Console.WriteLine(so.name);
                }
            }
            else
            {

                for (int j = 0; j < songs.Count; j++)
                {
                    if (songs[j].typeList == typeForPrint)
                    {
                        Console.WriteLine(songs[j].name);
                    }
                }
            }
        }
    }

    class Song
    {
        public string typeList;
        public string name;
        public string time;

        public Song(string type, string inputName, string inputTime)
        {
            this.typeList = type;
            this.name = inputName;
            this.time = inputTime;
        }
    }
}
