using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            List<string> decryptedMessages = new List<string>();

            while (true)
            {
                string message = Console.ReadLine();
                
                if(message == "end")
                {
                    break;
                }

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < message.Length; i++)
                {
                    char currentChar = message[i];
                    sb.Append((char)(currentChar - key));
                }

                decryptedMessages.Add(sb.ToString());
            }

            string pattern = @"\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*\!(?<behaviour>[GN])\!";

            for (int i = 0; i < decryptedMessages.Count; i++)
            {
                string message = decryptedMessages[i];

                if (Regex.IsMatch(message, pattern))
                {
                    string name = Regex.Match(message, pattern).Groups["name"].Value;
                    string behaviour = Regex.Match(message, pattern).Groups["behaviour"].Value;

                    if(behaviour == "G")
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
