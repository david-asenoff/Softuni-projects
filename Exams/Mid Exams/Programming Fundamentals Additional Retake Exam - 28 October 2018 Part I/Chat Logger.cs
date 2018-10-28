using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Chat_Logger
{
    class Program
    {
        static int PositionMessage(string msg, List<string> messages)
        {
            int result = -1;

            for (int i = 0; i < messages.Count; i++)
            {
                if(messages[i] == msg)
                {
                    result = i;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<string> messages = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end")
                {
                    break;
                }

                List<string> commandsInfo = input.Split(' ').ToList();

                string command = commandsInfo[0];
                string message = commandsInfo[1];
                int position = PositionMessage(message, messages);

                if (command == "Chat")
                {
                    messages.Add(message);
                }
                else if(command == "Delete")
                {
                    if(position >= 0)
                    {
                        messages.Remove(message);
                    }
                }
                else if(command == "Edit")
                {
                    string updatesMessage = commandsInfo[2];

                    if (position >= 0)
                    {
                        messages[position] = updatesMessage;
                    }
                }
                else if(command == "Pin")
                {
                    if (position >= 0)
                    {
                        messages.RemoveAt(position);
                        messages.Add(message);
                    }
                }
                else if (command == "Spam")
                {
                    List<string> newmessages = commandsInfo.Skip(1).ToList();

                    foreach(string msg in newmessages)
                    {
                        messages.Add(msg);
                    }
                }
            }

            foreach(string msg in messages)
            {
                Console.WriteLine(msg);
            }
        }
    }
}
