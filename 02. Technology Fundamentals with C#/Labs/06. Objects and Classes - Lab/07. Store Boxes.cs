using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end")
                {
                    break;
                }

                List<string> inputBox = input.Split(' ').ToList();

                string serialNumber = inputBox[0];
                string itemNane = inputBox[1];
                double itemPrice = double.Parse(inputBox[3]);
                int itemQuantity = int.Parse(inputBox[2]);

                Box newBox = new Box(serialNumber, new Item(itemNane, itemPrice), itemQuantity);

                newBox.PriceForBox = itemQuantity * itemPrice;

                boxes.Add(newBox);
            }

            List<Box> orderedBoxes = boxes.OrderBy(order => order.PriceForBox).ToList();

            for(int i = (orderedBoxes.Count -1); i>=0; i--)
            {
                Console.WriteLine($"{orderedBoxes[i].SerialNumber}");
                Console.WriteLine($"-- { orderedBoxes[i].BoxItem.Name} - ${orderedBoxes[i].BoxItem.Price:F2}: {orderedBoxes[i].ItemQuantity}");
                Console.WriteLine($"-- ${orderedBoxes[i].PriceForBox:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Item(string inputName, double inputPrice)
        {
            this.Name = inputName;
            this.Price = inputPrice;
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }

        public Item BoxItem { get; set; }

        public int ItemQuantity { get; set; }

        public double PriceForBox { get; set; }

        public Box(string number, Item item, int quantity)
        {
            this.SerialNumber = number;
            this.ItemQuantity = quantity;
            this.BoxItem = item;
        }
    }
}
