using MongoDB.Bson;
using MongoDB.Driver;
using iTextSharp.text.pdf;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;

namespace UISearcher
{
    /// <summary>
    /// takes in a document and removes all irrelevant words braces and others
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// calling the database
        /// </summary>
        private IMongoCollection<BsonDocument> collection;

        /// <summary>
        /// collecting the database that was used in whichever class this is called in
        /// </summary>
        /// <param name="collection"></param>
        public Parser(IMongoCollection<BsonDocument> collection)
        {
            this.collection = collection;
        }

        /// <summary>
        /// Method that collects the filepath and the words to remove and removes them from the document using their respective extension method
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="NotSupportedException"></exception>
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

        /// <summary>
        /// removes words from a textfile
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
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
        /// <summary>
        /// remove the wanted words from a word document
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromWordDocument(string filePath, string[] wordsToRemove)
        {
            // Use a Word document processing library (e.g., OpenXML SDK, Aspose.Words) to manipulate the document's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }

        /// <summary>
        /// remove the unwanted words from a pdf
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromPdf(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }

        /// <summary>
        /// remove the wanted words or special characters from a HTML page
        /// </summary>
        /// <param name="filePath"></param>h
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromHTML(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }

        /// <summary>
        /// remove the unwanted words from a presentation file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromPPT(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }

        /// <summary>
        /// remove the unwanted words from XML
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromXML(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }

        /// <summary>
        /// remove the unwanted words from XLS
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromXLS(string filePath, string[] wordsToRemove)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            return filePath;
        }
    }
}