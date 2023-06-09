using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MP3FileStream
{
    public class ID3Tag
    {
        public bool IsValid { get; set; } // TODO: maybe redundant, because we already have exceptions

        private byte[] _tagIdBytes = new byte[3];
        private byte[] _titleBytes = new byte[30];
        private byte[] _artistBytes = new byte[30];
        private byte[] _albumBytes = new byte[30];
        private byte[] _yearBytes = new byte[4];
        private byte[] _commentBytes = new byte[30];
        private byte[] _genreBytes = new byte[1];

        private string _TagId;
        private string _Title;
        private string _Artist;
        private string _Album;
        private string _Year;
        private string _Comment;
        private string _Genre;

        public string TagId
        {
            get { return _TagId; }
            set
            {
                if (value.Length != 3 && value != "TAG")
                    throw new Exception();
                _TagId = value;
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (value.Length > 30)
                    throw new Exception();
                _Title = value;
            }
        }

        public string Artist
        {
            get { return _Artist; }
            set
            {
                if (value.Length > 30)
                    throw new Exception();
                _Artist = value;
            }
        }

        public string Album
        {
            get { return _Album; }
            set
            {
                if (value.Length > 30)
                    throw new Exception();
                _Album = value;
            }
        }

        public string Year
        {
            get { return _Year; }
            set
            {
                if (value.Length > 4)
                    throw new Exception();
                _Year = value;
            }
        }

        public string Comment
        {
            get { return _Comment; }
            set
            {
                if (value.Length > 30)
                    throw new Exception();
                _Comment = value;
            }
        }

        public string Genre
        {
            get { return _Genre; }
            set
            {
                if (value.Length != 1)
                    throw new Exception();
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
                throw new Exception(); //TODO: 

            byte[] bytes = new byte[128];
            stream.Seek(-128, SeekOrigin.End);
            stream.Read(bytes, 0, bytes.Length);

            return FromBytes(bytes);
        }

        // TODO:
        public static ID3Tag FromBytes(byte[] bytes)
        {
            if (bytes.Length != 128)
                throw new Exception(); //TODO: 

            byte[] tagIdBytes = bytes.Take(3).ToArray();;
            byte[] titleBytes = bytes.Skip(3).Take(30).ToArray();
            byte[] artistBytes = bytes.Skip(33).Take(30).ToArray();
            byte[] albumBytes = bytes.Skip(63).Take(30).ToArray();
            byte[] yearBytes = bytes.Skip(93).Take(4).ToArray();
            byte[] commentBytes = bytes.Skip(97).Take(30).ToArray();
            byte[] genreBytes = bytes.Skip(127).Take(1).ToArray();

            return new ID3Tag(tagIdBytes, titleBytes, artistBytes, albumBytes, yearBytes, commentBytes, genreBytes);
        }

        public override string ToString()
        {
            string s = "Not valid MP3Gui file";
            if (IsValid)
            {
                s = $"Title: {Title}\n" +
                    $"Artist: {Artist}\n" +
                    $"Album: {Album}\n" +
                    $"Title: {Year}\n" +
                    $"Title: {Comment}\n" +
                    $"Title: {Genre}";
            }

            return s;
        }
    }
}