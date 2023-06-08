using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Files
{
    public static class IOHandler
    {
        public static HashSet<string> GetAllExtensionsFromDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            HashSet<string> extensions = new HashSet<string>();

            foreach (FileInfo file in dir.GetFiles())
                extensions.Add(file.Extension.ToLower());

            return extensions;
        }

        // Exception ... maybe because D.DriveType = cd room
        public static string GetAllDrivesInfo()
        {
            string s = "";
            DriveInfo[] drives = DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).ToArray();
            foreach (DriveInfo drive in drives)
                s += $"Drive {drive.Name}. Size {drive.TotalSize}. Free space {drive.AvailableFreeSpace}\n";
            return s;
        }
    }
}