using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Files
{
    public static class IoHandler
    {
        public static HashSet<string> GetAllExtensionsFromDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            HashSet<string> extensions = new HashSet<string>();

            foreach (FileInfo file in dir.GetFiles())
                extensions.Add(file.Extension.ToLower());

            return extensions;
        }

        public static string GetAllDrivesInfo()
        {
            string s = string.Empty;
            DriveInfo[] drives = DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).ToArray();
            foreach (DriveInfo drive in drives)
                s += $"Drive {drive.Name}. Size {drive.TotalSize}. Free space {drive.AvailableFreeSpace}\n";
            return s;
        }
    }
}