using System;
using System.Linq;
using System.Text;
using MP3FileStream;
using NUnit.Framework;

namespace MP3FileStreamTests
{
    //TODO: more cases
    [TestFixture]
    public class FromBytesTests
    {
        [Test]
        public void ValidByteID3Test()
        {
            byte[] tag = FromString("TAG", 3);
            byte[] title = FromString("Best track");
            byte[] artist = FromString("Best artist");
            byte[] album = FromString("Best album");
            byte[] year = FromString("1997", 4);
            byte[] comment = FromString("amazing");
            byte[] genre = FromString("1", 1); //TODO: Genre improvement

            //TODO: SHITCODE 
            byte[] bytes = tag.Concat(title).Concat(artist).Concat(album).Concat(year).Concat(comment)
                .Concat(genre).ToArray();


            ID3Tag id3Tag;
            id3Tag = ID3Tag.FromBytes(bytes);


            Assert.NotNull(id3Tag);
            Assert.AreEqual("Best track", id3Tag.Title);
            Assert.AreEqual("Best artist", id3Tag.Artist);
            Assert.AreEqual("Best album", id3Tag.Album);
            Assert.AreEqual("1997", id3Tag.Year);
            Assert.AreEqual("amazing", id3Tag.Comment);
        }

        private static string FillToLenght(string s, int lenght)
        {
            return s + String.Concat(Enumerable.Repeat("\0", lenght - s.Length));
        }

        private static byte[] FromString(string s, int maxLength = 30)
        {
            string filledS = FillToLenght(s, maxLength);
            return Encoding.ASCII.GetBytes(filledS);
        }
    }
}