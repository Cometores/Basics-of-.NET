using System;

namespace Vehicles
{
    public class Bicycle : Vehicle
    {
        private BicycleTypes _Types { get; set; }
        private bool _IsLit { get; set; }

        public Bicycle(string name, BicycleTypes types, bool isLit)
        {
            Name = name;
            _Types = types;
            _IsLit = isLit;
        }

        public override void MovesBy()
        {
            string output = $"Bicycle {Name} is a {_Types}" +
                            $" and is " + (_IsLit ? "" : "un") + "lit\n";
            Console.WriteLine(output);
        }
    }
}