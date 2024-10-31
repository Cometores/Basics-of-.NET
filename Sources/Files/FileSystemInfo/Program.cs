using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemInfo
{
    internal static class Program
    {
        private static readonly string Dir = Directory.GetParent(Directory.GetCurrentDirectory()).
            Parent.FullName + "\\others";
        
        public static void Main()
        {
            // 1) Get All Extensions
            Console.WriteLine("Extensions in 'others' folder are:");
            IEnumerable<string> extensions = FileSystemInfo.GetAllExtensionsFromDirectory(Dir);
            foreach (string extension in extensions)
                Console.WriteLine("\t" + extension);

            // 2) Get All Drivers Info
            Console.WriteLine("\nInformation about drives:");
            Console.WriteLine(FileSystemInfo.GetAllDrivesInfo());
        }
    }
}