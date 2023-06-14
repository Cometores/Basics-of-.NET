using System;
using System.Linq;
using System.Text;

namespace MP3FileStream
{
    public static class StringExtensions
    {
        /// <summary>
        /// Creates a bit string from the string, taking into account the length for Id3Tag.
        /// </summary>
        public static byte[] BytesFromString(this string s, int length = 30)
        {
            return Encoding.ASCII.GetBytes(s.PadRight(length, '\0'));
        }
    }
}