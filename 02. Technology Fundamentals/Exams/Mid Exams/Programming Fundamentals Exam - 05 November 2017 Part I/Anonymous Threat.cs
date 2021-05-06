using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "3:1")
                {
                    break;
                }

                List<string> inputInfo = input.Split(' ').ToList();

                string command = inputInfo[0];
                int indexOne = int.Parse(inputInfo[1]);
                int indexTwo = int.Parse(inputInfo[2]);

                if(command == "merge")
                {
                    if(indexOne > inputLine.Count - 1 || indexTwo <= 0)
                    {
                        continue;
                    }

                    if(indexOne < 0)
                    {
                        indexOne = 0;                      
                    }

                    if(indexTwo < 0)
                    {
                        indexTwo = 0;
                    }

                    if (indexTwo > (inputLine.Count - 1))
                    {                      
                        indexTwo = inputLine.Count - 1;
                    }

                    if(indexOne > (inputLine.Count - 1))
                    {
                        indexOne = inputLine.Count - 1;
                    }

                    if(indexOne == indexTwo)
                    {
                        continue;
                    }

                    string result = "";

                    for (int i = indexOne; i <= indexTwo; i++)
                    {
                        result += inputLine[i];
                    }

                    inputLine.Insert(indexOne, result);
                    inputLine.RemoveRange(indexOne + 1, indexTwo - indexOne + 1);
                }
                else if( command == "divide")
                {
                    string stringForDivide = inputLine[indexOne];
                    int count = stringForDivide.Length / indexTwo;
                    int startIndex = 0;

                    if (indexTwo <= 0 || indexTwo > stringForDivide.Length)
                    {
                        continue;
                    }

                    if (stringForDivide.Length % indexTwo == 0)
                    {                     
                        for (int i = 1; i <= indexTwo; i++)
                        {
                            string res = stringForDivide.Substring(startIndex, count);
                            inputLine.Insert(indexOne + i, res);
                            startIndex += count;
                        }

                        inputLine.RemoveAt(indexOne);
                    }
                    else
                    {
                        for (int i = 1; i <= indexTwo; i++)
                        {
                            if (i == indexTwo)
                            {
                                int lastLength = stringForDivide.Length - (indexTwo - 1) * count;
                                count = lastLength;
                            }

                            string res = stringForDivide.Substring(startIndex, count);
                            inputLine.Insert(indexOne + i, res);
                            startIndex += count;
                        }

                        inputLine.RemoveAt(indexOne);
                    }
                }
            }

            Console.WriteLine(string.Join(' ', inputLine));
        }
    }
}
