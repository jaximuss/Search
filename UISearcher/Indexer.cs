using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISearcher
{
    public class Indexer
    {
        public Dictionary<string, List<string>> invertedIndex;

        public Indexer()
        {
            invertedIndex = new Dictionary<string, List<string>>();
        }

        public void IndexDocument(string documentId, string documentText)
        {
            Tokenizer tokenizer = new Tokenizer();
            string[] tokens = tokenizer.TokenizeText(documentText);

            foreach (string token in tokens)
            {
                if (!invertedIndex.ContainsKey(token))
                {
                    invertedIndex[token] = new List<string>();
                }

                if (!invertedIndex[token].Contains(documentId))
                {
                    invertedIndex[token].Add(documentId);
                }
            }
        }

        public void PrintInvertedIndex()
        {
            foreach (KeyValuePair<string, List<string>> entry in invertedIndex)
            {
                Console.WriteLine($"Token: {entry.Key}");
                Console.WriteLine("Documents: " + string.Join(", ", entry.Value));
                Console.WriteLine();
            }
        }
    }
}
