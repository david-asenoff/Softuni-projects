using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Foods.MainDishes;

namespace Restaurant.Foods.Starters
{
    class Fish:MainDish
    {
        private const int grams = 22;
        public Fish(string name, decimal price) : base(name, price, grams)
        {
            this.Grams = grams;
        }
    }
}
