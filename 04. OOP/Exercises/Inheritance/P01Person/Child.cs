using System;

namespace P01Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {

        }

        private int age;

        public int Age
        {
            get => this.age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException(Exception.ChildCannotBeAboveFifteen());
                }

                this.age = value;
            }
        }
    }
}