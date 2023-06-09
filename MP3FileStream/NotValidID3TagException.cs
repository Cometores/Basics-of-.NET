using System;

namespace MP3FileStream
{
    public class NotValidID3TagException : NotValidMP3FileException
    {
        public NotValidID3TagException()
        {
        }

        public NotValidID3TagException(string message) : base(message)
        {
        }
        
        public NotValidID3TagException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}