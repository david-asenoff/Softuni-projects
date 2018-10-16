using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            Dictionary<string, int> countedWords = new Dictionary<string, int>();

            foreach(string word in words)
            {
                int length = word.Length;
                countedWords.Add(word, length);
            }

            countedWords = countedWords.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, x => x.Value);

            foreach(var word in countedWords)
            {
                Console.WriteLine(word.Key);
            }
        }
    }
}
