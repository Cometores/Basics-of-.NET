using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FsInformation
{
    public static class FsInformation
    {
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