using System;
using System.Collections.Generic;
using Anagram;
using NUnit.Framework;

namespace AnagramTests
{
    [TestFixture]
    public class AnagramGeneratorTests
    {
        [Test]
        public void Test1()
        {
            string s = "tor";
            
            List<string> anagrams = AnagramGenerator.GetAllAnagrams(s);

            Assert.Contains("tor", anagrams);
            Assert.Contains("rot", anagrams);
            Assert.Contains("ort", anagrams);
        }
    }
}