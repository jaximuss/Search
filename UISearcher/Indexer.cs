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

        public string IndexDocument(string document)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            // Split the document into words
            string[] words = document.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Count the occurrences of each word
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            // Build a string with the word counts
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var entry in wordCounts)
            {
                resultBuilder.AppendLine($"{entry.Key}: {entry.Value}");
            }

            // Return the result string
            return resultBuilder.ToString();
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
