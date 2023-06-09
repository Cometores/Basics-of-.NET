using System;

namespace MP3FileStream
{
    public class NotValidMP3FileException : Exception
    {
        public NotValidMP3FileException()
        {
        }

        public NotValidMP3FileException(string message = "File is too small") : base(message)
        {
        }
        
        public NotValidMP3FileException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}