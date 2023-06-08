using System;
using System.Collections.Generic;
using System.IO;

namespace Files
{
    internal class Program
    {
        private static string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).
            Parent.FullName + "\\others";
        
        
        public static void Main(string[] args)
        {
            IEnumerable<string> extensions = IOHandler.GetAllExtensionsFromDirectory(_dir);
            foreach (string extension in extensions)
            {
                Console.WriteLine(extension);
            }

            Console.WriteLine(IOHandler.GetAllDrivesInfo());
        }
    }
}