using P05BorderControl.Interfaces;

namespace P05BorderControl.Models
{
    public class Robot:IRobot
    {
        public string Model { get; private set; }
        public string Id { get; private set; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
}
