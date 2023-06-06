using System;

namespace Vehicles
{
    public enum CarManufacturer
    {
        Volvo,
        Volkswagen,
        Toyota
    }
    
    public class Car : Vehicle
    {
        public CarManufacturer Manufacturer { get; set; }
        public int Doors { get; set; }
        private bool IsAutomatic { get; set; }

        public Car(string name, int passengers, int doors,
            CarManufacturer manufacturer, bool isAutomatic, int wheels = 4)
        {
            this.Name = name;
            this.Wheels = wheels;
            this.Passengers = passengers;
            this.Doors = doors;
            this.Manufacturer = manufacturer;
            this.IsAutomatic = isAutomatic;
        }

        public override void MovesBy()
        {
            string output = $"Car {Name} from {Manufacturer} has:" +
                            $"\n\t{Wheels} wheels and {Doors} doors" +
                            $"\n\t{Passengers} passengers at max" +
                            $"\n\tand has " + (IsAutomatic ? "automatic" : "manual") +" transmission\n";
            Console.WriteLine(output);
        }
    }
}