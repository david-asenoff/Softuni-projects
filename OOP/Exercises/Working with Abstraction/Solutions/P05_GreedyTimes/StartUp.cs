namespace GreedyTimes
{
    using System;

    public class Startup
    {
        static void Main()
        {
            var capacity = long.Parse(Console.ReadLine());
            var bag = new Bag(capacity);

            var safeContent = Console.ReadLine()
                ?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (safeContent != null)
                for (int i = 0; i < safeContent.Length; i += 2)
                {
                    var name = safeContent[i];
                    var amount = long.Parse(safeContent[i + 1]);

                    bag.AddItem(new Item(name, amount));
                }

            Console.WriteLine(bag);
        }
    }
}