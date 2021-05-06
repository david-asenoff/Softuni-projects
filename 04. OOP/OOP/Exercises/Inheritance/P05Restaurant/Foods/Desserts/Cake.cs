namespace Restaurant.Foods.Desserts
{
    class Cake:Dessert
    {
        private new const decimal Price = 5m;
        private new const double Grams = 250;
        private new const double Calories = 1000;
        public Cake(string name) 
            : base(name, Price, Grams, Calories)
        {
        }
    }
}
