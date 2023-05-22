using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Common;
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
        private IMongoCollection<BsonDocument> collection;

        public Parser(IMongoCollection<BsonDocument> collection)
        {
            this.collection = collection;
        }


        public string RemoveWordsFromDocument(string filePath, string[] wordsToRemove)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            // Get the file extension
            var extension = Path.GetExtension(filePath).ToLower();

            // Process the document based on the file extension
            switch (extension)
            {
                case ".txt":
                    return RemoveWordsFromTextFile(filePath, wordsToRemove);
                case ".doc":
                case ".docx":
                    return RemoveWordsFromWordDocument(filePath, wordsToRemove);
                case ".pdf":
                    return RemoveWordsFromPdf(filePath, wordsToRemove);
                case ".html":
                    return RemoveWordsFromHTML(filePath, wordsToRemove);
                case ".xml":
                    return RemoveWordsFromXML(filePath, wordsToRemove);
                case ".ppt":
                    return RemoveWordsFromPPT(filePath, wordsToRemove);
                case ".xls":
                    return RemoveWordsFromXLS(filePath, wordsToRemove);
                // Add support for other file types if needed
                default:
                    throw new NotSupportedException("Unsupported file format.");
            }
        }

        private string RemoveWordsFromTextFile(string filePath, string[] wordsToRemove)
        {
            string content = File.ReadAllText(filePath);

            // Split the document text into words
            string[] words = content.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Remove the irrelevant words
            List<string> filteredWords = new List<string>();

            foreach (string word in words)
            {
                if (!wordsToRemove.Contains(word, StringComparer.OrdinalIgnoreCase))
                {
                    filteredWords.Add(word);
                }
            }

            // Join the remaining words back into cleaned text
            string cleanedText = string.Join(" ", filteredWords);

            return cleanedText;
        }

        private string RemoveWordsFromWordDocument(string filePath, string[] wordsToRemove)
        {
            // Use a Word document processing library (e.g., OpenXML SDK, Aspose.Words) to manipulate the document's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }

        private string RemoveWordsFromPdf(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }
        private string RemoveWordsFromHTML(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }
        private string RemoveWordsFromPPT(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }
        private string RemoveWordsFromXML(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }
        private string RemoveWordsFromXLS(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }
    }
}