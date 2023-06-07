using System;
using System.IO;

namespace MP3FileStream
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; // BinaryRW folder
            path += "\\others\\ID3v1.mp3";

            ID3Tag tag = new ID3Tag(path);
            Console.WriteLine(tag);
        }
    }
}