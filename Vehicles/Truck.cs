using System;

namespace Vehicles
{
    public class Truck: Vehicle
    {
        private float _MaxCarryWeight { get; set; }

        public Truck(string name, int wheels, int passengers, float maxCarryWeight)
        {
            Name = name;
            _Wheels = wheels;
            _Passengers = passengers;
            _MaxCarryWeight = maxCarryWeight;
        }
        
        public override void MovesBy()
        {
            string output = $"Truck {Name} has:" +
                            $"\n\t{_Wheels} wheels" +
                            $"\n\t{_Passengers} passengers at max" +
                            $"\n\tand can carry max {_MaxCarryWeight}kg\n";
            Console.WriteLine(output);
        }
    }
}