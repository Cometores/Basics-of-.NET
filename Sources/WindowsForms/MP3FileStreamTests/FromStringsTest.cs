using System;
using System.Linq;
using MP3FileStream;
using NUnit.Framework;

namespace MP3FileStreamTests
{
    [TestFixture]
    public class FromStringsTest
    {
        [Test]
        [TestCase("Best track",
        "Best artist",
        "Best album",
        "1997",
        "amazing",
        "98")]
        [TestCase("Super old song",
            "Pleb",
            "AArgh",
            "97",
            "amazing",
            "11")]
        public void FromStrings_CompleteValues_ValidId3Tag(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            ID3Tag id3Tag;
            id3Tag = ID3Tag.FromStrings(title, artist, album, year, comment, genre);

            Assert.NotNull(id3Tag);
            Assert.AreEqual(title, id3Tag.Title);
            Assert.AreEqual(artist, id3Tag.Artist);
            Assert.AreEqual(album, id3Tag.Album);
            Assert.AreEqual(year, id3Tag.Year);
            Assert.AreEqual(comment, id3Tag.Comment);
            Assert.AreEqual((GenreTypes)Convert.ToInt32(genre), id3Tag.Genre);
        }
        
        [Test]
        [TestCase("Best track",
            "Best artist",
            "Best album",
            "abc",
            "amazing",
            "98")]
        public void FromStrings_YearNotNumber_ThrowsNotValidID3TagException(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            var exception = Assert.Throws<NotValidID3TagException>(
                () => ID3Tag.FromStrings(title, artist, album, year, comment, genre));
            Assert.AreEqual("Year must be a number", exception.Message);
        }
        
        [Test]
        [TestCase("Best track",
            "Best artist",
            "Best album",
            "3001",
            "amazing",
            "98")]
        public void FromStrings_YearToBig_ThrowsNotValidID3TagException(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            var exception = Assert.Throws<NotValidID3TagException>(
                () => ID3Tag.FromStrings(title, artist, album, year, comment, genre));
            Assert.AreEqual($"The year {year} hasn't come yet", exception.Message);
        }
    }
}