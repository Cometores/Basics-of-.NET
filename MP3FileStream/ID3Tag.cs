using System;
using System.IO;
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

        private string _tagIdString;
        private string _titleString;
        private string _artistString;
        private string _albumString;
        private string _yearString;
        private string _commentString;
        private string _genreString;

        public string TagId
        {
            get { return _tagIdString; }
            set
            {
                if (value.Length != 3 && value != "TAG")
                    throw new Exception();
                _tagIdString = value;
            }
        }

        public string Title
        {
            get { return _titleString; }
            set { _titleString = value; }
        }

        public string Artist
        {
            get { return _artistString; }
            set { _artistString = value; }
        }

        public string Album
        {
            get { return _albumString; }
            set { _albumString = value; }
        }

        public string Year
        {
            get { return _yearString; }
            set { _yearString = value; }
        }

        public string Comment
        {
            get { return _commentString; }
            set { _commentString = value; }
        }

        public string Genre
        {
            get { return _genreString; }
            set { _genreString = value; }
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

            stream.Seek(-128, SeekOrigin.End);

            byte[] tagIdBytes = new byte[3];
            byte[] titleBytes = new byte[30];
            byte[] artistBytes = new byte[30];
            byte[] albumBytes = new byte[30];
            byte[] yearBytes = new byte[4];
            byte[] commentBytes = new byte[30];
            byte[] genreBytes = new byte[1];

            stream.Read(tagIdBytes, 0, tagIdBytes.Length);
            stream.Read(titleBytes, 0, titleBytes.Length);
            stream.Read(artistBytes, 0, artistBytes.Length);
            stream.Read(albumBytes, 0, albumBytes.Length);
            stream.Read(yearBytes, 0, yearBytes.Length);
            stream.Read(commentBytes, 0, commentBytes.Length);
            stream.Read(genreBytes, 0, genreBytes.Length);

            return new ID3Tag(tagIdBytes, titleBytes, artistBytes, albumBytes, yearBytes, commentBytes, genreBytes);
        }

        // TODO:
        public static ID3Tag FromBytes(byte[] bytes)
        {
            byte[] tagIdBytes = new byte[3];
            byte[] titleBytes = new byte[30];
            byte[] artistBytes = new byte[30];
            byte[] albumBytes = new byte[30];
            byte[] yearBytes = new byte[4];
            byte[] commentBytes = new byte[30];
            byte[] genreBytes = new byte[1];
            
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