namespace GreedyTimes
{
    public class Item
    {
        public Item(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; }

        public long Quantity { get; }

        public string Type
        {
            get
            {
                if (this.Name.Length == 3)
                {
                    return "Cash";
                }
                else if (this.Name.ToLower() == "gold")
                {
                    return "Gold";
                }
                else if (this.Name.ToLower().EndsWith("gem"))
                {
                    return "Gem";
                }

                return string.Empty;
            }
        }
    }
}