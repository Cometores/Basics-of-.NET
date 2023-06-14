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
            byte[] tag = "TAG".BytesFromString(3);
            byte[] title = "Best track".BytesFromString();
            byte[] artist = "Best artist".BytesFromString();
            byte[] album = "Best album".BytesFromString();
            byte[] year = "1997".BytesFromString(4);
            byte[] comment = "amazing".BytesFromString();
            byte[] genre = new byte[] { 3 };

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
            Assert.AreEqual(GenreTypes.Dance, id3Tag.Genre);
        }
    }
}