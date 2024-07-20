using System;
using System.IO;
using MP3FileStream;
using NUnit.Framework;

namespace MP3FileStreamTests
{
    [TestFixture]
    public class FromStreamTests
    {
        private static string _projDirPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        [Test]
        public void FromStream_FileStream_ValidId3Tag()
        {
            ID3Tag id3Tag;
            string mp3Path = _projDirPath + "\\others\\ID3v1.mp3";

            using (FileStream fs = File.OpenRead(mp3Path))
                id3Tag = ID3Tag.FromStream(fs);
            
            Assert.NotNull(id3Tag);
            Assert.AreEqual("Deskcenter On Track", id3Tag.Title);
            Assert.AreEqual("Deskcenter", id3Tag.Artist);
            Assert.AreEqual("DC Superhits 1", id3Tag.Album);
            Assert.AreEqual("2023", id3Tag.Year);
            Assert.AreEqual("Sick", id3Tag.Comment);
            Assert.AreEqual(GenreTypes.PowerBallad, id3Tag.Genre);
        }

        [Test]
        public void FromStream_FileStream_Png_ThrowsNotValidId3TagException()
        {
            ID3Tag tag;
            string _pngPath = _projDirPath + "\\others\\Lenna_ComputerVision.png";

            using (FileStream fs = File.OpenRead(_pngPath))
            {
                var exception = Assert.Throws<NotValidID3TagException>(() => ID3Tag.FromStream(fs));
                Assert.AreEqual("Not valid ID TAG", exception.Message);
            }
        }

        [Test]
        public void FromStream_FileStream_Txt_ThrowsNotValidId3TagException()
        {
            ID3Tag tag;
            string _txtPath = _projDirPath + "\\others\\lorem.txt";

            using (FileStream fs = File.OpenRead(_txtPath))
            {
                var exception = Assert.Throws<NotValidID3TagException>(() => ID3Tag.FromStream(fs));
                Assert.AreEqual("Not valid ID TAG", exception.Message);
            }
        }
    }
}