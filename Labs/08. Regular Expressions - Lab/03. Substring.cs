using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            while (true)
            {
                int index = text.IndexOf(word.ToLower());

                if (index < 0)
                {
                    break;
                }

                text = text.Remove(index, word.Length);
            }

            Console.WriteLine(text);
        }
    }
}
