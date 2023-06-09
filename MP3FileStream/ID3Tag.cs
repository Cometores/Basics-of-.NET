using System;
using System.IO;
using System.Linq;
using System.Text;

/*
 * Notes for Chris
 * 1) IsValid is redundant, because we already throw Exceptions. Or?
 * 2) Did I defined Exceptions right?
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
                if (value.Length != 3 && value != "TAG")
                    throw new NotValidID3TagException("Not valid id-TAG");
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
                _Title = value;
            }
        }

        public string Artist
        {
            get => _Artist;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Artist name is too long");
                _Artist = value;
            }
        }

        public string Album
        {
            get => _Album;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Album name is too long");
                _Album = value;
            }
        }

        public string Year
        {
            get => _Year;
            set
            {
                if (value.Length > 4)
                    throw new NotValidID3TagException("Year is too long");
                _Year = value;
            }
        }

        public string Comment
        {
            get => _Comment;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException("Comment is too long");
                _Comment = value;
            }
        }

        public string Genre
        {
            get => _Genre;
            set
            {
                if (value.Length != 1)
                    throw new NotValidID3TagException("Genre need to be 1 byte");
                // if (Convert.ToInt32(value) < 0 || Convert.ToInt32(value) > 147)
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
                throw new NotValidMP3FileException();

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