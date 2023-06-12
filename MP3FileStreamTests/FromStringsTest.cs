using System.Linq;
using MP3FileStream;
using NUnit.Framework;

namespace MP3FileStreamTests
{
    [TestFixture]
    public class FromStringsTest
    {
        [Test]
        public void ValidStrigsID3Test()
        {
            string title = "Best track";
            string artist = "Best artist";
            string album = "Best album";
            string year = "1997";
            string comment = "amazing";
            string genre = "1"; //TODO: Genre improvement


            ID3Tag id3Tag;
            id3Tag = ID3Tag.FromStrings(title, artist, album, year, comment, genre);


            Assert.NotNull(id3Tag);
            Assert.AreEqual("Best track", id3Tag.Title);
            Assert.AreEqual("Best artist", id3Tag.Artist);
            Assert.AreEqual("Best album", id3Tag.Album);
            Assert.AreEqual("1997", id3Tag.Year);
            Assert.AreEqual("amazing", id3Tag.Comment);
        }
    }
}