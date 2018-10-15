using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            Dictionary<string, int> countedWords = new Dictionary<string, int>();

            foreach(string oldword in words)
            {
                string word = oldword.ToLower();

                if (countedWords.ContainsKey(word))
                {
                    countedWords[word]++;
                }
                else
                {
                    countedWords.Add(word, 1);
                }
            }

            countedWords = countedWords.Where(x => x.Value % 2 != 0).ToDictionary(x => x.Key, x => x.Value);

            foreach(var word in countedWords)
            {
                Console.Write($"{word.Key} ");
            }
        }
    }
}
