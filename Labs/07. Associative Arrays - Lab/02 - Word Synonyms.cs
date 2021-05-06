using System;
using System.Collections.Generic;

namespace _02___Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            for (int i = 0; i < number; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (words.ContainsKey(word))
                {
                    if (!words[word].Contains(synonym))
                    {
                        words[word].Add(synonym);
                    }
                }
                else
                {
                    words.Add(word, new List<string> { synonym});
                }
            }

            foreach(var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
