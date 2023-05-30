using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISearcher
{

    /// <summary>
    /// keeps every word from a document in a dictionary
    /// </summary>
    public class Indexer
    {
        private Dictionary<string, int> wordCounts;

        /// <summary>
        /// intializes the wordcounts dictionary when the class is called
        /// </summary>
        public Indexer()
        {
            wordCounts = new Dictionary<string, int>();
        }

        /// <summary>
        /// indexes a given document which has been parsed and returns the wordcounts
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
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

        /// <summary>
        /// removes special characters like { \) from the document
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string RemoveSpecialCharacters(string word)
        {
            // Remove any special characters from the word
            string cleanedWord = new string(word.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            return cleanedWord.ToLower();
        }

        /// <summary>
        /// a function that returns the wordcounts
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetWordCounts()
        {
            return wordCounts;
        }
    }
}
