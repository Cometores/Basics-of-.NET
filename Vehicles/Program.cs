using System.Collections.Generic;

namespace Vehicles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Pedestrian andrey = new Pedestrian("Andrey", 24, "male");
            Pedestrian sonya = new Pedestrian("Sonya", 20, "female");
            Bicycle bmx = new Bicycle("Turbo-V22xB", BicycleType.Bmx, false);
            Bicycle bicycle = new Bicycle("StraßenKiller", BicycleType.Cargo, true);
            Car golf = new Car("Golf", 5, 4, CarManufacturer.Volkswagen, true);
            Car supra = new Car("Supra", 2, 2, CarManufacturer.Toyota, false);
            Truck megatruck = new Truck("Megatruck", 8, 3, 1260.2f);
            Truck supertruck = new Truck("Supertruck", 6, 1, 799.9f);

            List<IMovable> vehicles = new List<IMovable>()
            {
                andrey, sonya, bmx, bicycle, golf, supra, megatruck, supertruck
            };

            foreach (IMovable trafficParticipant in vehicles)
            {
                trafficParticipant.MovesBy();
            }
        }
    }
}