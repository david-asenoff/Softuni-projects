using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _04.Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split()
                .ToArray();
            string[] sites = Console.ReadLine()
                .Split()
                .ToArray();

            
                TryToCall(phoneNumbers);
                TryToBrowse(sites);
          
        }

        private static void TryToBrowse(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    Smartphone smartphone = new Smartphone { Site = site };
                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }
        }

        private static void TryToCall(string[] phoneNumbers)
        {
            
            foreach (var number in phoneNumbers)
            {
                try
                {
                    Smartphone smartphone = new Smartphone { Number = number };
                    Console.WriteLine(smartphone.Call());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
