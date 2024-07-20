using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private CarManufacturerTypes _ManufacturerTypes { get; set; }
        private int _Doors { get; set; }
        private bool _IsAutomatic { get; set; }

        public Car(string name, int passengers, int doors,
            CarManufacturerTypes manufacturerTypes, bool isAutomatic, int wheels = 4)
        {
            Name = name;
            _Wheels = wheels;
            _Passengers = passengers;
            _Doors = doors;
            _ManufacturerTypes = manufacturerTypes;
            _IsAutomatic = isAutomatic;
        }

        public override void MovesBy()
        {
            string output = $"Car {Name} from {_ManufacturerTypes} has:" +
                            $"\n\t{_Wheels} wheels and {_Doors} doors" +
                            $"\n\t{_Passengers} passengers at max" +
                            $"\n\tand has " + (_IsAutomatic ? "automatic" : "manual") + " transmission\n";
            Console.WriteLine(output);
        }
    }
}