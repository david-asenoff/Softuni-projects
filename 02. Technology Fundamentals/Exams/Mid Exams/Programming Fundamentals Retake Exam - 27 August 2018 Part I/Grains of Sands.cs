using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Grains_of_Sands
{
    class Program
    {
        static int IsValueExist(int value, List<int> numbers)
        {
            int position = -1;

            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] == value)
                {
                    position = i;
                    break;
                }
            }

            return position;
        }

        static void Main(string[] args)
        {
            List<int> sands = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Mort")
                {
                    Console.WriteLine(string.Join(' ', sands));
                    break;
                }

                List<string> commandInfo = input.Split(' ').ToList();
                string command = commandInfo[0];
                int value = int.Parse(commandInfo[1]);
                int position = IsValueExist(value, sands);

                if (command == "Add")
                {
                    sands.Add(value);
                }
                else if (command == "Remove")
                {
                    if (position >= 0)
                    {
                        sands.RemoveAt(position);
                    }
                    else if (value >= 0 && value < sands.Count)
                    {
                        sands.RemoveAt(value);
                    }
                }
                else if (command == "Replace")
                {
                    int newValue = int.Parse(commandInfo[2]);

                    if (position >= 0)
                    {
                        sands[position] = newValue;
                    }
                }
                else if (command == "Increase")
                {
                    int increaseNumber = 0;
                    int count = 0;

                    for (int i = 0; i < sands.Count; i++)
                    {
                        if(sands[i] >= value)
                        {
                            increaseNumber = sands[i];
                            count++;
                            break;
                        }
                    }

                    if (count == 0)
                    {
                        increaseNumber = sands[sands.Count - 1];
                    }
 
                    for (int i = 0; i < sands.Count; i++)
                    {
                        sands[i] += increaseNumber;
                    }
                }
                else if(command == "Collapse")
                {
                    for (int i = 0; i < sands.Count; i++)
                    {
                        if (sands[i] < value)
                        {
                            sands.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
    }
}
