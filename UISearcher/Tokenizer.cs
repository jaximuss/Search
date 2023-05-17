using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISearcher
{
    public class Tokenizer
    {
        /// <summary>
        /// Cleans the text gotten from the document by removing and formatting unwanted characters and stop words
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Cleaned up text</returns>
 
        public string[] TokenizeText(string text)
        {
            // remove non alphanumeric-characters
            string cleanedText = new string(text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            cleanedText.ToLower().Trim();

            // Stop words to be excluded
            List<string> stopWords = new List<string>() { "a", "an", "and", "are", "as", "at", "be", "by", "for", "from", "has", "he", "in", "is", "it", "its", "on", "of", "that", "the", "to", "was", "were", "will", "with" };
            string[] words = cleanedText.Split(" ");
            List<string> cleanedWords = new List<string>();
            foreach (string word in words)
            {
                if (!stopWords.Contains(word))
                {
                    cleanedWords.Add(word);
                }
            }
            cleanedText = string.Join(" ", cleanedWords);

            string[] tokens = cleanedText.Split(new char[] { ' ', '\t', '\r', '\n', ',', '.', '!', '?', ':', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens;


        }


    }
}
