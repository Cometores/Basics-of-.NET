namespace Vehicles
{
    public abstract class Vehicle: IMovable
    {
        protected int _Wheels { get; set; }
        protected int _Passengers { get; set; }
        public abstract void MovesBy();
        public string Name { get; set; }
    }
}