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
            byte[] tag = ID3Tag.BytesFromString("TAG", 3);
            byte[] title = ID3Tag.BytesFromString("Best track");
            byte[] artist = ID3Tag.BytesFromString("Best artist");
            byte[] album = ID3Tag.BytesFromString("Best album");
            byte[] year = ID3Tag.BytesFromString("1997", 4);
            byte[] comment = ID3Tag.BytesFromString("amazing");
            byte[] genre = ID3Tag.BytesFromString("1", 1); //TODO: Genre improvement

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
    }
}