using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Memory_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputs = "";

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Visual Studio crash")
                {
                    break;
                }

                inputs += input + " ";
            }

            List<string> listInputs = inputs.Split(' ').ToList();

            while (true)
            {
                int startIndex = listInputs.IndexOf("32656");

                if (startIndex < 0)
                {
                    break;
                }

                int indexLength = startIndex + 4;
                int length = int.Parse(listInputs[indexLength]);
                int indexStartWord = startIndex + 6;
                int indexEndWord = indexStartWord + length - 1;
                string word = "";

                for (int i = indexStartWord; i <= indexEndWord; i++)
                {
                    word += (char)int.Parse(listInputs[i]);
                }

                Console.WriteLine(word);

                listInputs.RemoveRange(0, indexEndWord + 1);
            }
        }
    }
}
