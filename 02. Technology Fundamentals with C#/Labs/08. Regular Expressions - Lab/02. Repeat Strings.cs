using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Count; i++)
            {
                string word = input[i];
                int count = word.Length;

                for (int j = 0; j < count; j++)
                {
                    result.Append(word);
                }
            }

            Console.WriteLine(result);
        }
    }
}
