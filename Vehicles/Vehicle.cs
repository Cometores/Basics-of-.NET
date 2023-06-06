namespace Vehicles
{
    public abstract class Vehicle: IMovable
    {
        protected int Wheels { get; set; }
        protected int Passengers { get; set; }
        public abstract void MovesBy();
        public string Name { get; set; }
    }
}