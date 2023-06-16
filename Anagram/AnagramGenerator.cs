using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anagram
{
    public static class AnagramGenerator
    {
        private static readonly string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static readonly string _germanDic = _dir + "\\others\\german.txt";

        public static List<string> GetAllAnagrams(string baseWord)
        {
            baseWord = baseWord.ToLower().Replace(" ","");;
            List<string> anagrams = new List<string>();
            Dictionary<char, int> baseWordSymbols = GetBaseWordSymbols(baseWord);

            using (StreamReader fs = new StreamReader(_germanDic))
            {
                string newWord;
                while (true)
                {
                    newWord = fs.ReadLine();
                    if (newWord == null)
                        break;
                    
                    newWord = newWord.ToLower().Replace(" ","");;

                    if (IsAnagram(baseWordSymbols, newWord))
                        anagrams.Add(newWord);
                }
            }

            return anagrams;
        }

        private static Dictionary<char, int> GetBaseWordSymbols(string baseWord)
        {
            Dictionary<char, int> baseWordSymbols = new Dictionary<char, int>();
            foreach (var symbol in baseWord)
            {
                if (baseWordSymbols.ContainsKey(symbol))
                    baseWordSymbols[symbol] += 1;
                else
                    baseWordSymbols.Add(symbol, 1);
            }

            return baseWordSymbols;
        }
        
        private static bool IsAnagram(Dictionary<char, int> baseWordSymbols, string newWord)
        {
            baseWordSymbols = new Dictionary<char, int>(baseWordSymbols);
            foreach (var symbol in newWord)
            {
                if (!baseWordSymbols.ContainsKey(symbol))
                    return false;

                baseWordSymbols[symbol] -= 1;
                if (baseWordSymbols[symbol] == 0)
                    baseWordSymbols.Remove(symbol);
            }
            
            if(baseWordSymbols.Count <= 0)
                return true;
            
            return false;
        }
    }
}