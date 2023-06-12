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
        public void ValidMp3Test()
        {
            ID3Tag tag;
            string mp3Path = _projDirPath + "\\others\\ID3v1.mp3";


            using (FileStream fs = File.OpenRead(mp3Path))
                tag = ID3Tag.FromStream(fs);


            Assert.NotNull(tag);
            Assert.AreEqual("Deskcenter On Track", tag.Title);
            Assert.AreEqual("Deskcenter", tag.Artist);
            Assert.AreEqual("DC Superhits 1", tag.Album);
            Assert.AreEqual("2023", tag.Year);
            Assert.AreEqual("Sick", tag.Comment);
            // TODO Genre test
        }

        [Test]
        public void InvalidPngTest()
        {
            ID3Tag tag;
            string _pngPath = _projDirPath + "\\others\\Lenna_ComputerVision.png";

            using (FileStream fs = File.OpenRead(_pngPath))
                Assert.Throws<NotValidID3TagException>(() => ID3Tag.FromStream(fs));

            // TODO: how to check Exception messages
        }

        [Test]
        public void InvalidTxtTest()
        {
            ID3Tag tag;
            string _txtPath = _projDirPath + "\\others\\lorem.txt";

            using (FileStream fs = File.OpenRead(_txtPath))
            {
                Assert.Throws<NotValidID3TagException>(() => ID3Tag.FromStream(fs));
            }

            // TODO: how to check Exception messages
        }
    }
}