using System;
using PlayersAndMonsters.Wizard;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DarkWizard alacazam  = new DarkWizard("Alacazam",100);

            Console.WriteLine(alacazam);
        }
    }
}
