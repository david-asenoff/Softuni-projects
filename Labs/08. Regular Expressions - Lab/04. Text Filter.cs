using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bannedWords = Console.ReadLine().Split(", ").ToList();

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Count; i++)
            {
                string word = bannedWords[i];
                string newWord = new string('*', word.Length);

                while(text.IndexOf(word) != -1)
                {
                    text = text.Replace(word, newWord);
                }
            }

            Console.WriteLine(text);
        }
    }
}
