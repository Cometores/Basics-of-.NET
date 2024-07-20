using System;
using System.Collections.Generic;
using System.IO;

namespace FsInformation
{
    internal class Program
    {
        private static string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).
            Parent.FullName + "\\others";
        
        
        public static void Main(string[] args)
        {
            // 1) Get All Extensions
            Console.WriteLine("Extensions in 'others' folder are:");
            IEnumerable<string> extensions = FsInformation.GetAllExtensionsFromDirectory(_dir);
            foreach (string extension in extensions)
                Console.WriteLine("\t" + extension);

            // 2) Get All Drivers Info
            Console.WriteLine("\nInformation about drives:");
            Console.WriteLine(FsInformation.GetAllDrivesInfo());
        }
    }
}