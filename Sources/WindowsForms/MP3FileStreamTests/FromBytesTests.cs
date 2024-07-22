using System;
using System.Linq;
using MP3FileStream;
using NUnit.Framework;

namespace MP3FileStreamTests
{
    [TestFixture]
    public class FromBytesTests
    {
        [Test]
        [TestCase("Best track",
            "Best artist",
            "Best album",
            "1890",
            "amazing",
            "3")]
        public void FromBytes_CompleteValues_ValidId3Tag(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            byte[] tagBytes = "TAG".ToBytes(3);
            byte[] titleBytes = title.ToBytes();
            byte[] artistBytes = artist.ToBytes();
            byte[] albumBytes = album.ToBytes();
            byte[] yearBytes = year.ToBytes(4);
            byte[] commentBytes = comment.ToBytes();
            byte[] genreBytes = new byte[] { (byte)Convert.ToInt32(genre) };

            byte[] bytes = tagBytes.Concat(titleBytes).Concat(artistBytes)
                .Concat(albumBytes).Concat(yearBytes).Concat(commentBytes)
                .Concat(genreBytes).ToArray();


            ID3Tag id3Tag = ID3Tag.FromBytes(bytes);


            Assert.NotNull(id3Tag);
            Assert.AreEqual(title, id3Tag.Title);
            Assert.AreEqual(artist, id3Tag.Artist);
            Assert.AreEqual(album, id3Tag.Album);
            Assert.AreEqual(year, id3Tag.Year);
            Assert.AreEqual(comment, id3Tag.Comment);
            Assert.AreEqual((GenreTypes)Convert.ToInt32(genre), id3Tag.Genre);
        }
        
        [Test]
        [TestCase("There is a hell believe me i've seen it, there is a hell",
            "Best artist",
            "Best album",
            "1890",
            "amazing",
            "3")]
        public void FromBytes_TitleTooLong_ThrowsNotValidMP3FileException(string title,
            string artist,
            string album,
            string year,
            string comment,
            string genre)
        {
            byte[] tagBytes = "TAG".ToBytes(3);
            byte[] titleBytes = title.ToBytes();
            byte[] artistBytes = artist.ToBytes();
            byte[] albumBytes = album.ToBytes();
            byte[] yearBytes = year.ToBytes(4);
            byte[] commentBytes = comment.ToBytes();
            byte[] genreBytes = new byte[] { (byte)Convert.ToInt32(genre) };

            byte[] bytes = tagBytes.Concat(titleBytes).Concat(artistBytes)
                .Concat(albumBytes).Concat(yearBytes).Concat(commentBytes)
                .Concat(genreBytes).ToArray();


            var exception = Assert.Throws<NotValidMP3FileException>(
                () => ID3Tag.FromBytes(bytes));
            Assert.AreEqual($"ID3 should be 128 bytes", exception.Message);
        }
    }
}