using System;
using System.IO;
using System.Linq;
using System.Text;

/*
 * Notes for Chris
 * 1) IsValid is redundant, because we already throw Exceptions. Or?
 * 2) Did I defined Exceptions right? They look like shitcode
 * 3) Length check in setters seems to be redundant, because we already define length in ID3Tag creation methonds
 * 4) Need to make more test cases. Is there an attribute for test method TODO that should be implemented?
 * 5) Need to improve genre, it doesn't work.
 * 6) Need to delete useless functions fileNameLabel_Click and SaveFileDialog1 in Form1.cs
 * that was created accidentally
 */
namespace MP3FileStream
{
    public class ID3Tag
    {
        public bool IsValid { get; set; } 

        private byte[] _tagIdBytes;
        private byte[] _titleBytes;
        private byte[] _artistBytes;
        private byte[] _albumBytes;
        private byte[] _yearBytes;
        private byte[] _commentBytes;
        private byte[] _genreBytes;

        private string _TagId;
        private string _Title;
        private string _Artist;
        private string _Album;
        private string _Year;
        private string _Comment;
        private string _Genre;

        public string TagId
        {
            get => _TagId;
            set
            {
                if (value.Length != 3 || value != "TAG")
                    throw new NotValidID3TagException("Not valid ID TAG");
                _TagId = value;
            }
        }

        public string Title
        {
            get => _Title;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Title is too long");
                _Title = value.Replace("\0", "");
            }
        }

        public string Artist
        {
            get => _Artist;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Artist name is too long");
                _Artist = value.Replace("\0", "");
            }
        }

        public string Album
        {
            get => _Album;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Album name is too long");
                _Album = value.Replace("\0", "");
            }
        }

        public string Year
        {
            get => _Year;
            set
            {
                if (value.Length > 4)
                    throw new NotValidID3TagException("Year is too long");
                if (Convert.ToInt32(value) > DateTime.Now.Year)
                    throw new NotValidID3TagException($"The year {value} hasn't come yet");
                _Year = value.Replace("\0", "");
            }
        }

        public string Comment
        {
            get => _Comment;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Comment is too long");
                _Comment = value.Replace("\0", "");
            }
        }

        public string Genre
        {
            get => _Genre;
            set
            {
                if (value.Length != 1)
                    throw new NotValidID3TagException("Genre need to be 1 byte");
                // if (Convert.ToInt32(value) < 0 || Convert.ToInt32(value) > 147) #TODO: Genre improvement needed
                //     throw new NotValidID3TagException("Genre can only take values from 0 to 147");
                _Genre = value;
            }
        }

        private ID3Tag(byte[] tagIdBytes,
            byte[] titleBytes,
            byte[] artistBytes,
            byte[] albumBytes,
            byte[] yearBytes,
            byte[] commentBytes,
            byte[] genreBytes)
        {
            TagId = Encoding.Default.GetString(tagIdBytes);
            _tagIdBytes = tagIdBytes;

            Title = Encoding.Default.GetString(titleBytes);
            _titleBytes = titleBytes;

            Artist = Encoding.Default.GetString(artistBytes);
            _artistBytes = artistBytes;

            Album = Encoding.Default.GetString(albumBytes);
            _albumBytes = albumBytes;

            Year = Encoding.Default.GetString(yearBytes);
            _yearBytes = yearBytes;

            Comment = Encoding.Default.GetString(commentBytes);
            _commentBytes = commentBytes;

            Genre = Encoding.Default.GetString(genreBytes);
            _genreBytes = genreBytes;

            IsValid = TagId.Equals("TAG");
        }

        public static ID3Tag FromStream(Stream stream)
        {
            if (stream.Length < 128)
                throw new NotValidMP3FileException(); 

            byte[] bytes = new byte[128];
            stream.Seek(-128, SeekOrigin.End);
            stream.Read(bytes, 0, bytes.Length);

            return FromBytes(bytes);
        }

        public static ID3Tag FromBytes(byte[] bytes)
        {
            if (bytes.Length != 128)
                throw new NotValidMP3FileException("ID3 should be 128 bytes");

            byte[] tagIdBytes = bytes.Take(3).ToArray();;
            byte[] titleBytes = bytes.Skip(3).Take(30).ToArray();
            byte[] artistBytes = bytes.Skip(33).Take(30).ToArray();
            byte[] albumBytes = bytes.Skip(63).Take(30).ToArray();
            byte[] yearBytes = bytes.Skip(93).Take(4).ToArray();
            byte[] commentBytes = bytes.Skip(97).Take(30).ToArray();
            byte[] genreBytes = bytes.Skip(127).Take(1).ToArray();

            return new ID3Tag(tagIdBytes, titleBytes, artistBytes, albumBytes, yearBytes, commentBytes, genreBytes);
        }

        public static ID3Tag FromStrings(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            byte[] tagIdBytes = ID3Tag.BytesFromString("TAG", 3);
            byte[] titleBytes = ID3Tag.BytesFromString(title);
            byte[] artistBytes = ID3Tag.BytesFromString(artist);
            byte[] albumBytes = ID3Tag.BytesFromString(album);
            byte[] yearBytes = ID3Tag.BytesFromString(year, 4);
            byte[] commentBytes = ID3Tag.BytesFromString(comment);
            byte[] genreBytes = ID3Tag.BytesFromString(genre, 1);
            
            return new ID3Tag(tagIdBytes, titleBytes, artistBytes, albumBytes, yearBytes, commentBytes, genreBytes);
        }

        public void ChangeID3Tag(FileStream stream)
        { 
            stream.Seek(-128, SeekOrigin.End);
            stream.Write(_tagIdBytes, 0, _tagIdBytes.Length);
            stream.Write(_titleBytes, 0, _titleBytes.Length);
            stream.Write(_artistBytes, 0, _artistBytes.Length);
            stream.Write(_albumBytes, 0, _albumBytes.Length);
            stream.Write(_yearBytes, 0, _yearBytes.Length);
            stream.Write(_commentBytes, 0, _commentBytes.Length);
            stream.Write(_genreBytes, 0, _genreBytes.Length);
        }
        
        /// <summary>
        /// Fills in the string with characters '\0' from C for the correct format of Id3Tag properties
        /// </summary>
        public static string FillStringToLenght(string s, int lenght)
        {
            return s + String.Concat(Enumerable.Repeat("\0", lenght - s.Length));
        }

        /// <summary>
        /// Creates a bit string from the string, taking into account the length for Id3Tag.
        /// </summary>
        public static byte[] BytesFromString(string s, int maxLength = 30)
        {
            string filledS = FillStringToLenght(s, maxLength);
            return Encoding.ASCII.GetBytes(filledS);
        }

        public override string ToString()
        {
            string s = "Not valid MP3Gui file";
            if (IsValid)
            {
                s = $"Title: {Title}\n" +
                    $"Artist: {Artist}\n" +
                    $"Album: {Album}\n" +
                    $"Year: {Year}\n" +
                    $"Comment: {Comment}\n" +
                    $"Genre: {Genre}";
            }

            return s;
        }
    }
}