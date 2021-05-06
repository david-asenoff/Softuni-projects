namespace GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private long capacity;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.Gems = new List<Gem>();
            this.Cash = new List<Cash>();
            this.GoldAmount = 0;
            this.GemsAmount = 0;
            this.CashAmount = 0;
        }

        public List<Gem> Gems { get; }

        public List<Cash> Cash { get; }

        public long GoldAmount { get; private set; }

        public long GemsAmount { get; private set; }

        public long CashAmount { get; private set; }

        public void AddItem(Item item)
        {
            if (item.Quantity > this.capacity)
            {
                return;
            }

            else if (CanTakeItem(item))
            {
                capacity -= item.Quantity;

                if (item.Type == "Gold")
                {
                    this.GoldAmount += item.Quantity;
                }

                else if (item.Type == "Gem")
                {
                    this.GemsAmount += item.Quantity;

                    if (this.Gems.Any(g => g.Name == item.Name) == false)
                    {
                        Gems.Add(new Gem(item.Name, 0));
                    }

                    var gem = Gems.FirstOrDefault(g => g.Name == item.Name);
                    gem.Quantity += item.Quantity;
                }
                else if (item.Type == "Cash")
                {
                    this.CashAmount += item.Quantity;

                    if (this.Cash.Any(c => c.Name == item.Name) == false)
                    {
                        this.Cash.Add(new Cash(item.Name, 0));
                    }

                    var cash = Cash.FirstOrDefault(c => c.Name == item.Name);
                    cash.Quantity += item.Quantity;
                }
            }
        }

        private bool CanTakeItem(Item item)
        {
            if (item.Type == "Cash")
            {
                return this.GoldAmount >= this.GemsAmount && this.GemsAmount >= (this.CashAmount + item.Quantity);
            }
            else if (item.Type == "Gold")
            {
                return (this.GoldAmount + item.Quantity) >= this.GemsAmount && this.GemsAmount >= this.CashAmount;
            }
            else if (item.Type == "Gem")
            {
                return this.GoldAmount >= (this.GemsAmount + item.Quantity) && (this.GemsAmount + item.Quantity) >= this.CashAmount;
            }

            return false;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.GoldAmount > 0)
            {
                result.AppendLine($"<Gold> ${this.GoldAmount}");
                result.AppendLine($"##Gold - {GoldAmount}");
            }
            if (this.GemsAmount > 0)
            {
                result.AppendLine($"<Gem> ${this.GemsAmount}");
                foreach (Gem gem in this.Gems.OrderByDescending(g => g.Name).ThenBy(g => g.Quantity))
                {
                    result.AppendLine($"##{gem.Name} - {gem.Quantity}");
                }
            }
            if (this.CashAmount > 0)
            {
                result.AppendLine($"<Cash> ${this.CashAmount}");
                foreach (Cash cash in this.Cash.OrderByDescending(c => c.Name).ThenBy(c => c.Quantity))
                {
                    result.AppendLine($"##{cash.Name} - {cash.Quantity}");
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}