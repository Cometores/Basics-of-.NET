using System;

namespace Vehicles
{
    public class Pedestrian: IMovable
    {
        public string Name { get; set; }
        private int _Age { get; set; }
        private string _Sex { get; set; }

        public Pedestrian(string name, int age, string sex)
        {
            Name = name;
            _Age = age;
            _Sex = sex;
        }

        public void MovesBy()
        {
            string output = $"Pedestrian {Name} is {_Age} years old and also {_Sex}\n";
            Console.WriteLine(output);
        }

    }
}