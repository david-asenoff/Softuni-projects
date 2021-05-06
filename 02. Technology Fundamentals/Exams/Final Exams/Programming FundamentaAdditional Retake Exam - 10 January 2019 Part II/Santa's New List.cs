using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Santa_s_New_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> children = new Dictionary<string, double>();
            //name, amount
            Dictionary<string, double> presents = new Dictionary<string, double>();
            //present, amount


            while (true)
            {
                string input = Console.ReadLine();

                if(input == "END")
                {
                    break;
                }

                List<string> inputInfo = input.Split("->").ToList();

                if(inputInfo[0] != "Remove")
                {
                    string name = inputInfo[0];
                    string type = inputInfo[1];
                    double amount = double.Parse(inputInfo[2]);

                    if (children.ContainsKey(name))
                    {
                        children[name] += amount;
                    }
                    else
                    {
                        children.Add(name, amount);
                    }

                    if (presents.ContainsKey(type))
                    {
                        presents[type] += amount;
                    }
                    else
                    {
                        presents.Add(type, amount);
                    }
                }
                else
                {
                    string name = inputInfo[1];

                    if (children.ContainsKey(name))
                    {
                        children.Remove(name);
                    }
                }
            }

            var orderedChildren = children.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine("Children:");

            foreach(var kvp in orderedChildren)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine("Presents:");

            foreach(var kvp in presents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
