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
        public void GetAllAnagrams_TorString_Test()
        {
            string s = "tor";
            
            List<string> anagrams = AnagramGenerator.GetAllAnagrams(s);

            Assert.Contains("tor", anagrams);
            Assert.Contains("rot", anagrams);
            Assert.Contains("ort", anagrams);
        }
        
        [Test]
        public void GetAllAnagrams_AlgeString_Test()
        {
            string s = "alge";
            
            List<string> anagrams = AnagramGenerator.GetAllAnagrams(s);

            Assert.Contains("alge", anagrams);
            Assert.Contains("egal", anagrams);
            Assert.Contains("lage", anagrams);
        }
    }
}