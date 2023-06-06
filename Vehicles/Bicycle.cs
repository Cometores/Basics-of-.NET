using System;

namespace Vehicles
{
    public enum BicycleType
    {
        Cargo,
        Bmx,
        Racing, 
        Recumbent, 
        Folding
    }
    public class Bicycle: IMovable
    {
        public string Name { get; set; }
        public BicycleType Type { get; set; }
        public bool IsLit { get; set; }

        public Bicycle(string name, BicycleType type, bool isLit)
        {
            Name = name;
            Type = type;
            IsLit = isLit;
        }

        public void MovesBy()
        {
            string output = $"Bicycle {Name} is a {Type}" +
                            $" and is " + (IsLit ? "" : "un") + "lit\n";
            Console.WriteLine(output);
        }
    }
}