using System.Collections.Generic;
using System.Linq;

namespace GearFactory
{
    public class Production
    {
        private readonly LinkedList<Gear> _gears;

        public Production()
        {
            this._gears = new LinkedList<Gear>();
        }

        public void AddGear(int weight)
        {
            _gears.AddLast(new Gear(weight));
        }

        public int[] GetGears()
        {
            return _gears.Select(item => item.Weight).ToArray();
        }


        public double GetAverageWeight()
        {
            return _gears.Average(item => item.Weight);
        }
    }

    public class Gear
    {
        public int Weight { get; set; }

        public Gear(int weight)
        {
            this.Weight = weight;
        }
    }
}