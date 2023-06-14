using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MP3FileStream
{
    public class ID3Tag
    {
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
        private GenreTypes _Genre;

        public string TagId
        {
            get => _TagId;
            private set
            {
                if (value.Length != 3 || value != "TAG")
                    throw new NotValidID3TagException(
                        "Not valid ID TAG");
                _TagId = value;
                _tagIdBytes = value.ToBytes(3);
            }
        }

        public string Title
        {
            get => _Title;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException(
                        "Title is too long");
                _Title = value.Replace("\0", "");
                _titleBytes = value.ToBytes();
            }
        }

        public string Artist
        {
            get => _Artist;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException(
                        "Artist name is too long");
                _Artist = value.Replace("\0", "");
                _artistBytes = value.ToBytes();
            }
        }

        public string Album
        {
            get => _Album;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException(
                        "Album name is too long");
                _Album = value.Replace("\0", "");
                _albumBytes = value.ToBytes();
            }
        }

        public string Year
        {
            get => _Year;
            set
            {
                try
                {
                    Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    throw new NotValidID3TagException(
                        "Year must be a number");
                }

                if (Convert.ToInt32(value) > DateTime.Now.Year 
                    || value.Length > 4)
                    throw new NotValidID3TagException(
                        $"The year {value} hasn't come yet");

                _Year = value.Replace("\0", "");
                _yearBytes = value.ToBytes(4);
            }
        }

        public string Comment
        {
            get => _Comment;
            set
            {
                if (value.Length > 30)
                    throw new NotValidID3TagException(
                        "Comment is too long");
                _Comment = value.Replace("\0", "");
                _commentBytes = value.ToBytes();
            }
        }

        public GenreTypes Genre
        {
            get => _Genre;
            set
            {
                if ((int)value > 147 || (int)value < 0)
                    throw new NotValidID3TagException(
                        "Genre can only take values from 0 to 147");
                _Genre = value;
                _genreBytes = new byte[] { (byte)value };
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
            Title = Encoding.Default.GetString(titleBytes);
            Artist = Encoding.Default.GetString(artistBytes);
            Album = Encoding.Default.GetString(albumBytes);
            Year = Encoding.Default.GetString(yearBytes);
            Comment = Encoding.Default.GetString(commentBytes);
            Genre = (GenreTypes)genreBytes[0];
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
                throw new NotValidMP3FileException(
                    "ID3 should be 128 bytes");

            byte[] tagIdBytes = bytes.Take(3).ToArray();
            byte[] titleBytes = bytes.Skip(3).Take(30).ToArray();
            byte[] artistBytes = bytes.Skip(33).Take(30).ToArray();
            byte[] albumBytes = bytes.Skip(63).Take(30).ToArray();
            byte[] yearBytes = bytes.Skip(93).Take(4).ToArray();
            byte[] commentBytes = bytes.Skip(97).Take(30).ToArray();
            byte[] genreBytes = bytes.Skip(127).Take(1).ToArray();

            return new ID3Tag(tagIdBytes, titleBytes, artistBytes, 
                albumBytes, yearBytes, commentBytes, genreBytes);
        }

        public static ID3Tag FromStrings(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            byte[] tagIdBytes = "TAG".ToBytes(3);
            byte[] titleBytes = title.ToBytes();
            byte[] artistBytes = artist.ToBytes();
            byte[] albumBytes = album.ToBytes();
            byte[] yearBytes = year.ToBytes(4);
            byte[] commentBytes = comment.ToBytes();
            byte[] genreBytes = new byte[] { (byte)Convert.ToInt32(genre) };

            return new ID3Tag(tagIdBytes, titleBytes, artistBytes, 
                albumBytes, yearBytes, commentBytes, genreBytes);
        }

        public void WriteToStream(FileStream stream)
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

        public override string ToString()
        {
            return $"Title: {Title}\n" +
                   $"Artist: {Artist}\n" +
                   $"Album: {Album}\n" +
                   $"Year: {Year}\n" +
                   $"Comment: {Comment}\n" +
                   $"Genre: {Genre}";
        }
    }
}