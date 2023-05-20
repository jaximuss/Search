using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISearcher
{
    public class Indexer
    {
        private Dictionary<string, int> wordCounts;

        public Indexer()
        {
            wordCounts = new Dictionary<string, int>();
        }

        public void IndexDocument(string[] words)
        {
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                string cleanedWord = RemoveSpecialCharacters(word);

                if (wordCounts.ContainsKey(cleanedWord))
                    wordCounts[cleanedWord]++;
                else
                    wordCounts[cleanedWord] = 1;
            }
        }

        private string RemoveSpecialCharacters(string word)
        {
            // Remove any special characters from the word
            string cleanedWord = new string(word.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            return cleanedWord.ToLower();
        }

        public Dictionary<string, int> GetWordCounts()
        {
            return wordCounts;
        }
    }
}
