using System;

namespace Vehicles
{
    public class Pedestrian: IMovable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public Pedestrian(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public void MovesBy()
        {
            string output = $"Pedestrian {Name} is {Age} years old and also {Sex}\n";
            Console.WriteLine(output);
        }

    }
}