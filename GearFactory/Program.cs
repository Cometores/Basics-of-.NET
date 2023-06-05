using System;

namespace Production
{
    internal class Program
    {
        private static Production production = new Production();
        private static int gearsAmount;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Greet();

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        FillTheGears();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        GetInfo();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        GetAverage();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        return;
                }
            }
        }

        public static void Greet()
        {
            Console.WriteLine("Press");
            Console.WriteLine("1: To fill the gears");
            Console.WriteLine("2: To get info about all gears");
            Console.WriteLine("3: To get the average weight of gears");
            Console.WriteLine("4: To end the program");
        }

        public static void FillTheGears()
        {
            Console.Clear();
            Console.WriteLine("You have selected the first option.\n" +
                              "How many gears were produced in total?");

            //TODO cases when it's not int
            gearsAmount = Convert.ToInt32(Console.ReadLine());

            //TODO event listener for backspace -> return to Main
            for (int i = 0; i < gearsAmount; i++)
            {
                Console.Clear();
                Console.WriteLine($"Enter the weight of gear no. {i + 1}");
                int gearWeight = Convert.ToInt32(Console.ReadLine());
                production.AddGear(gearWeight);
            }
        }

        public static void GetInfo()
        {
            Console.Clear();
            Console.WriteLine("You have selected the second option.\n" +
                              $"A total of {gearsAmount} gears were produced. Their weights are:");

            foreach (int gearWeight in production.GetGears())
            {
                Console.Write($"{gearWeight} ");
            }

            Console.ReadKey();
        }

        public static void GetAverage()
        {
            double gearsAverageWeight = production.GetAverageWeight();
            Console.Clear();
            Console.WriteLine("You have selected the third option.\n" +
                              $"The average weight of the gears is {gearsAverageWeight}.\n\n" +
                              $"Press any key to continue");
            Console.ReadKey();
        }
    }
}