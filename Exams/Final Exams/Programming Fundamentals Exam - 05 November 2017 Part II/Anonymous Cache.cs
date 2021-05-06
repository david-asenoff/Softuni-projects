using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Anonymous_Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dataSets = new Dictionary<string, Dictionary<string, long>>();

            Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "thetinggoesskrra")
                {
                    break;
                }

                if(input.IndexOf('|') >=0)
                {
                    List<string> inputInfo = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    string dataKey = inputInfo[0];

                    List<string> inputInfo2 = inputInfo[1].Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    long dataSize = long.Parse(inputInfo2[0]);

                    string dataSet = inputInfo2[1];

                    if (dataSets.ContainsKey(dataSet))
                    {
                        if (!dataSets[dataSet].ContainsKey(dataKey))
                        {
                            dataSets[dataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            dataSets[dataSet][dataKey] = dataSize;
                        }
                    }
                    else
                    {
                        if (cache.ContainsKey(dataSet))
                        {
                            cache[dataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            Dictionary<string, long> currentDictionary = new Dictionary<string, long>();

                            currentDictionary.Add(dataKey, dataSize);

                            cache.Add(dataSet, currentDictionary);
                        }
                    }
                }
                else
                {
                    string dataSet = input;

                    if (!dataSets.ContainsKey(dataSet))
                    {
                        dataSets.Add(dataSet, new Dictionary<string, long>());

                        if (cache.ContainsKey(dataSet))
                        {
                            dataSets[dataSet] = cache[dataSet];

                            cache.Remove(dataSet);
                        }
                    }
                }
            }


            if (dataSets.Count > 0)
            {
                var maxDataSet = dataSets.OrderByDescending(x => x.Value.Sum(a => a.Value)).First();

                Dictionary<string, long> maxValues = maxDataSet.Value;

                Console.WriteLine($"Data Set: {maxDataSet.Key}, Total Size: {maxValues.Values.Sum()}");

                foreach (var item in maxValues)
                {
                    Console.WriteLine($"$.{item.Key}");
                }
            }          
        }
    }
}
