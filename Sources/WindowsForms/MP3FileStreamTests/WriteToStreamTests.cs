using System;
using System.IO;
using MP3FileStream;
using NUnit.Framework;

namespace MP3FileStreamTests
{
    [TestFixture]
    public class WriteToStreamTests
    {
        private static string _projDirPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static string _mp3OriginalPath = _projDirPath + "\\others\\ID3v1.mp3";
        private static string _mp3TestPath = _projDirPath + "\\others\\test.mp3";
        
        [SetUp]
        public void Setup()
        {
            if(File.Exists(_mp3TestPath))
                File.Delete(_mp3TestPath);
        }
        
        [Test]
        public void WriteToStream_CompleteStringsValues_ValidMP3File()
        {
            File.Copy(_mp3OriginalPath, _mp3TestPath);
            
            string title = "Best track";
            string artist = "Best artist";
            string album = "Best album";
            string year = "1997";
            string comment = "amazing";
            string genre = "18"; 

            ID3Tag id3Tag = ID3Tag.FromStrings(title, artist, album, year, comment, genre);

            
            using (FileStream fs = File.OpenWrite(_mp3TestPath))
                id3Tag.WriteToStream(fs);
            
            
            using (FileStream fs = File.OpenRead(_mp3TestPath))
                id3Tag = ID3Tag.FromStream(fs);
            
            Assert.NotNull(id3Tag);
            Assert.AreEqual("Best track", id3Tag.Title);
            Assert.AreEqual("Best artist", id3Tag.Artist);
            Assert.AreEqual("Best album", id3Tag.Album);
            Assert.AreEqual("1997", id3Tag.Year);
            Assert.AreEqual("amazing", id3Tag.Comment);
            Assert.AreEqual(GenreTypes.Techno, id3Tag.Genre);
        }
        
        /* Comment this if you need to save the test file */
        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            if(File.Exists(_mp3TestPath))
                File.Delete(_mp3TestPath);
        }
    }
}