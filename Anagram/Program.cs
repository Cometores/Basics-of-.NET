using System;
using System.Collections.Generic;

namespace Anagram
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            IEnumerable<string> anagrams = AnagramGenerator.GetAllAnagrams(s);

            int i = 1;
            foreach (var anagram in anagrams)
                Console.WriteLine($"{i++}: {anagram}");
        }
    }
}