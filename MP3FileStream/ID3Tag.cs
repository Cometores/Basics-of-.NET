using System;
using System.IO;
using System.Text;

namespace MP3FileStream
{
    public class ID3Tag
    {
        public bool IsValid { get; set; }
        public byte[] Tagid { get; set; } = new byte[3];
        public byte[] Title { get; set; } = new byte[30];
        public byte[] Artist { get; set; } = new byte[30];
        public byte[] Album { get; set; } = new byte[30];
        public byte[] Year { get; set; } = new byte[4];
        public byte[] Comment { get; set; } = new byte[30];
        public byte[] Genre { get; set; } = new byte[1];

        public ID3Tag(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                // if file < 128 Byte -> not valid
                if (fs.Length >= 128)
                {
                    fs.Seek(-128, SeekOrigin.End);
                    fs.Read(Tagid, 0, Tagid.Length);
                    fs.Read(Title, 0, Title.Length);
                    fs.Read(Artist, 0, Artist.Length);
                    fs.Read(Album, 0, Album.Length);
                    fs.Read(Year, 0, Year.Length);
                    fs.Read(Comment, 0, Comment.Length);
                    fs.Read(Genre, 0, Genre.Length);

                    string TagidStr = Encoding.Default.GetString(Tagid);
                    IsValid = TagidStr.Equals("TAG");
                }
                else
                {
                    IsValid = false;
                    //TODO: throw Exception
                }
            }
        }

        public override string ToString()
        {
            string s = "Not valid MP3 file";
            if (IsValid)
            {
                s = $"Title: {Encoding.Default.GetString(Title)}\n" +
                    $"Artist: {Encoding.Default.GetString(Artist)}\n" +
                    $"Album: {Encoding.Default.GetString(Album)}\n" +
                    $"Title: {Encoding.Default.GetString(Year)}\n" +
                    $"Title: {Encoding.Default.GetString(Comment)}\n" +
                    $"Title: {Encoding.Default.GetString(Genre)}";
            }

            return s;
        }
    }
}