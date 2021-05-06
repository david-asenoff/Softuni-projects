using P05BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using P05BorderControl.Interfaces;

namespace P05BorderControl.Core
{
    public class Engine
    {
        private List<Citizen> citizens;
        private List<Robot> robots;
        private readonly List<IIdentifiable> ids;

        public Engine()
        {
                citizens = new List<Citizen>();
                robots = new List<Robot>();
                ids = new List<IIdentifiable>();
        }

        public void Run()
        {
            Initialization();
            GetFakeIds();
        }


        private void GetFakeIds()
        {
            string fakeId = Console.ReadLine();

            foreach (var id in ids)
            {
                if (id.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(id.Id);
                }
            }
        }

        private void Initialization()
        {
            string input = string.Empty;

            while ((input=Console.ReadLine())!="End")
            {
                string[] args = input
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (args.Length==2)
                {
                     Robot robot = new Robot(args[0],args[1]);  
                     ids.Add(robot);

                }
                else
                {
                    Citizen citizen = new Citizen(args[0],int.Parse(args[1]),args[2]);
                    ids.Add(citizen);
                }
            }
        }
    }
}
