using P05BorderControl.Interfaces;

namespace P05BorderControl.Models
{
    public class Citizen:ICitizen
    {
        public string Name { get; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
