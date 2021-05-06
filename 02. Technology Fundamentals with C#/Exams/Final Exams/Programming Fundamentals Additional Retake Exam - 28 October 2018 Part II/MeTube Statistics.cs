using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._MeTube_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> views = new Dictionary<string, int>();
            Dictionary<string, int> likes = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "stats time")
                {
                    break;
                }

                if(command.IndexOf('-') > 0)
                {
                    List<string> commandInfo = command.Split('-').ToList();
                    string name = commandInfo[0];
                    int numberViews = int.Parse(commandInfo[1]);

                    if (views.ContainsKey(name))
                    {
                        views[name] += numberViews;
                    }
                    else
                    {
                        views.Add(name, numberViews);
                        likes.Add(name, 0);
                    }
                }
                else if (command.IndexOf(':') > 0)
                {
                    List<string> commandInfo = command.Split(':').ToList();
                    string type = commandInfo[0];
                    string name = commandInfo[1];

                    if(type == "like")
                    {
                        if (likes.ContainsKey(name))
                        {
                            likes[name] += 1;
                        }
                    }
                    else if (type == "dislike")
                    {
                        if (likes.ContainsKey(name))
                        {
                            likes[name] -= 1;
                        }
                    }
                }
            }

            string order = Console.ReadLine();

            if(order == "by views")
            {
                var sortedViews = views.OrderByDescending(x => x.Value);

                foreach(var item in sortedViews)
                {
                    Console.WriteLine($"{item.Key} - {item.Value} views - {likes[item.Key]} likes");
                }
            }
            else if(order == "by likes")
            {
                var sortedViews = likes.OrderByDescending(x => x.Value);

                foreach (var item in sortedViews)
                {
                    Console.WriteLine($"{item.Key} - {views[item.Key]} views - {item.Value} likes");
                }
            }
        }
    }
}
