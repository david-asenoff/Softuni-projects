namespace CarSalesman
{
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;//default values, as they are not mandatory
            this.Efficiency = "n/a";//default values, as they are not mandatory
        }

        public Engine(string model, int power, int displacement, string efficiency)
        :this(model,power)
        {
            //this.model = model;
            //this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:")
                .AppendLine($"    Power: {this.Power}");
            sb.AppendLine(this.Displacement == 0 ? $"    Displacement: n/a" : $"    Displacement: {this.Displacement}");
            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().Trim();
        }

        public static void Initialization(List<Engine> engines, string[] inputParts)
        {
            string model = inputParts[0];
            int power = int.Parse(inputParts[1]);
            Engine engine = new Engine(model, power);
            if (inputParts.Length == 3)
            {
                if (int.TryParse(inputParts[2], out int displacement))
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = inputParts[2];
                }
            }
            else if (inputParts.Length == 4)
            {
                int displacement = int.Parse(inputParts[2]);
                string efficiency = inputParts[3];
                engine.Displacement = displacement;
                engine.Efficiency = efficiency;
            }

            engines.Add(engine);
        }
    }
}