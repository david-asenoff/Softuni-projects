namespace P05_GreedyTimes
{
    public class Gold
    {
        public Gold(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; }

        public long Quantity { get; set; }
    }
}
