using System;

namespace Vehicles
{
    public class Truck: Vehicle
    {
        public float MaxCarryWeight { get; set; }

        public Truck(string name, int wheels, int passengers, float maxCarryWeight)
        {
            this.Name = name;
            this.Wheels = wheels;
            this.Passengers = passengers;
            this.MaxCarryWeight = maxCarryWeight;
        }
        
        public override void MovesBy()
        {
            string output = $"Truck {Name} has:" +
                            $"\n\t{Wheels} wheels" +
                            $"\n\t{Passengers} passengers at max" +
                            $"\n\tand can carry max {MaxCarryWeight}kg\n";
            Console.WriteLine(output);
        }
    }
}