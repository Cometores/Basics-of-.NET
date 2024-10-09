using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FsInformation
{
    public static class FsInformation
    {
        /// <summary>
        /// Collects all file extensions used in the directory.
        /// </summary>
        /// <param name="path">Absolute path to the Directory you want to scan.</param>
        /// <returns>File extensions</returns>
        public static HashSet<string> GetAllExtensionsFromDirectory(string path)
        {
            if(!Directory.Exists(path))
                return null;
            
            HashSet<string> extensions = new HashSet<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            
            foreach (FileInfo file in dir.GetFiles())
                extensions.Add(file.Extension.ToLower());

            return extensions;
        }

        /// <summary>
        /// Collects information about all the disks on your computer.
        /// </summary>
        /// <returns>String in a format "Drive name, Size, Free space"</returns>
        public static string GetAllDrivesInfo()
        {
            string result = string.Empty;
            DriveInfo[] drives = DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).ToArray();
            foreach (DriveInfo drive in drives)
                result += $"Drive {drive.Name}\n" +
                          $"\tSize {SizeToString(drive.TotalSize)}\n" +
                          $"\tFree space {SizeToString(drive.AvailableFreeSpace)}\n";
            return result;
        }

        /// <summary>
        /// Converts the size given in bytes in a string.
        /// </summary>
        /// <param name="size">Amount of bytes</param>
        /// <returns>String in a format "0.00 K/M/GB"</returns>
        private static string SizeToString(double size)
        {
            string[] units = new[] { "Byte", "KB", "MB", "GB", "TB", "EB" };
            int idx = 0;
            while (size >= 1024 && idx < units.Length)
            {
                size /= 1024;
                idx++;
            }

            return $"{size:0.00} {units[idx]}";
        }
    }
}