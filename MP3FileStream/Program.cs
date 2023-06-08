using System;
using System.IO;

namespace MP3FileStream
{
    internal class Program
    {
        private static string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static string _mp3Path = _dir + "\\others\\ID3v1.mp3";
        public static void Main(string[] args)
        {
            using (FileStream fs = File.OpenRead(_mp3Path))
            {
                ID3Tag tag = ID3Tag.FromStream(fs);
                Console.WriteLine(tag);
            }
        }
    }
}