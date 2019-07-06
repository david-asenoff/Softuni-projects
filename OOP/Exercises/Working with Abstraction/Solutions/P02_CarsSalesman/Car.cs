using System.Collections.Generic;

namespace CarSalesman
{
    using System.Text;

    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight, string color)
        :this(model,engine)
        {
            //this.model = model;
            //this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine}");
            if (this.Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().Trim();
        }

        public static void Initialization(string[] inputParts, string engineModel, Engine engine1, Car car, List<Car> cars)
        {
            if (inputParts.Length == 3)
            {
                if (int.TryParse(inputParts[2], out int weight))
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = inputParts[2];
                }
            }
            else if (inputParts.Length == 4)
            {
                int weight = int.Parse(inputParts[2]);
                string color = inputParts[3];
                car.Weight = weight;
                car.Color = color;
            }

            cars.Add(car);
        }
    }
}