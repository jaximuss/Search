using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;

namespace UISearcher
{
    public class Parser
    {
        /*
        public string ExtractTextContent(string directoryPath)
        {
            List<string> textContentList = new List<string>();

            string[] documentFiles = Directory.GetFiles(directoryPath, "*.pdf|*.doc|*.docx|*.pptx|*.xls|*.xlsx|*.txt|*.html|*.xml");

            foreach (string documentFile in documentFiles)
            {
                string textContent = ExtractTextFromDocument(documentFile);
                textContentList.Add(textContent);
            }

            return textContentList;
        }
        */

        public TextExtractionResult ExtractTextFromDocument(string filepath)
        {
            using (var stream = new FileStream(filepath, FileMode.Open))
            {
                var extractor = new TextExtractor();
                var textContent = extractor.Extract(stream.ToString());
                return textContent;
            }
        }
    }
}
