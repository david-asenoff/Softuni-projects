using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hornet_Comm
{
    class Program
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            List<List<string>> broadcasts = new List<List<string>>();
            List<List<string>> messages = new List<List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Hornet is Green")
                {
                    break;
                }

                List<string> inputInfo = input.Split(" <-> ").ToList();

                string firstQuery = inputInfo[0];
                string secondQuery = inputInfo[1];

                int countDigitsFirst = 0;
                int countDigitsSecond = 0;
                int countLettersSecond = 0;

                for (int i = 0; i < firstQuery.Length; i++)
                {
                    if (Char.IsDigit(firstQuery[i]))
                    {
                        countDigitsFirst++;
                    }
                }

                for(int a = 0; a < secondQuery.Length; a++)
                {
                    if (Char.IsDigit(secondQuery[a]))
                    {
                        countDigitsSecond++;
                    }
                    if (Char.IsLetter(secondQuery[a]))
                    {
                        countLettersSecond++;
                    }
                }

                if(countDigitsFirst==firstQuery.Length && 
                    (countDigitsSecond == secondQuery.Length || countLettersSecond == secondQuery.Length))
                {
                    string reversed = Reverse(firstQuery);

                    firstQuery = reversed;

                    inputInfo[0] = firstQuery;

                    messages.Add(inputInfo);
                }
                else if (countDigitsFirst == 0)
                {
                    string frequency = "";

                    for (int i = 0; i < secondQuery.Length; i++)
                    {
                        if (char.IsLetter(secondQuery[i]))
                        {
                            if (char.IsUpper(secondQuery[i]))
                            {
                                int newChar = Char.ToLower(secondQuery[i]);
                                frequency += (char)newChar;
                            }
                            else if (char.IsLower(secondQuery[i]))
                            {
                                int newChar = Char.ToUpper(secondQuery[i]);
                                frequency += (char)newChar;
                            }
                        }
                        else
                        {
                            frequency += secondQuery[i];
                        }
                    }

                    inputInfo[1] = frequency;

                    inputInfo.Reverse();

                    broadcasts.Add(inputInfo);
                }
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {
                for (int i = 0; i < broadcasts.Count; i++)
                {
                    Console.WriteLine($"{broadcasts[i][0]} -> {broadcasts[i][1]}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");

            if (messages.Count > 0)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    Console.WriteLine($"{messages[i][0]} -> {messages[i][1]}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
