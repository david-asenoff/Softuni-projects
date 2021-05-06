using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languages = new Dictionary<string, int>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "exam finished")
                {
                    break;
                }

                List<string> inputInfo = input.Split('-').ToList();

                string name = inputInfo[0];

                if(inputInfo.Count == 3)
                {
                    string language = inputInfo[1];
                    int points = int.Parse(inputInfo[2]);

                    if (users.ContainsKey(name))
                    {
                        if(users[name] < points)
                        {
                            users[name] = points;
                        }
                    }
                    else
                    {
                        users.Add(name, points);
                    }

                    if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                    else
                    {
                        languages.Add(language, 1);
                    }
                }
                else
                {
                    if (users.ContainsKey(name))
                    {
                        users.Remove(name);
                    }
                }
            }

            var orderedUsers = users.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            var orderedLanguages = languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine("Results:");

            foreach(var kvp in orderedUsers)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in orderedLanguages)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
