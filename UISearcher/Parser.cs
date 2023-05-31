using MongoDB.Bson;
using MongoDB.Driver;
using iTextSharp.text.pdf;
using SharpCompress.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using TikaOnDotNet.TextExtraction;
using iTextSharp.text.pdf.parser;
using System.Xml;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using HtmlAgilityPack;

namespace UISearcher
{
    /// <summary>
    /// takes in a document and removes all irrelevant words braces and others
    /// </summary>
    public class Parser
    {
        string[] wordsToRemove = { "a", "an", "the", "of", "in", "on", "at", "to", "for", "with", "and", "or", "but", "is", "are",
            "was", "were", "has", "have", "had", "be", "been", "being", "it", "that", "this", "these", "those", "as", "from", "by",
            "about", "into", "through", "over", "under", "above", "below", "between", "among", "while", "during", "before", "after",
            "since", "until", "unless", "although", "though", "even", "if", "unless", "not", "nor", "yet", "so", "because",
            "since", "due", "both", "either", "neither", "whether", "where", "when", "who", "whom", "which", "what", "whose", "how" };

        TextExtractor textExtractor = new TextExtractor();
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
        public string RemoveWordsFromDocument(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            // Get the file extension
            var extension = System.IO.Path.GetExtension(filePath).ToLower();

            // Process the document based on the file extension
            switch (extension)
            {
                case ".txt":
                    return RemoveWordsFromTextFile(filePath);
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
                    return RemoveWordsFromXLS(filePath);
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
        private string RemoveWordsFromTextFile(string filePath)
        {
            string content = File.ReadAllText(filePath);

            // Split the document text into words
            string[] words = content.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Remove the cleaned words
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
        /// remove the unwanted words from a pdf and return the text
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromPdf(string filePath, string[] wordsToRemove)
        {
            StringBuilder content = new StringBuilder();
            using (PdfReader reader = new PdfReader(filePath))
            {
                // Iterate over each page of the PDF document
                for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
                {
                    // Use a text extraction strategy to extract text from the page
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, pageNumber, strategy);

                    content.Append(pageText);
                }
            }
            return content.ToString();
        }

        /// <summary>
        /// remove the wanted words or special characters from a HTML page
        /// </summary>
        /// <param name="filePath"></param>h
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromHTML(string filePath, string[] wordsToRemove)
        {
            // Load the HTML document using HtmlAgilityPack
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load(filePath);

            // Extract the HTML content as a string
            string htmlString = htmlDoc.DocumentNode.InnerText;
            return htmlString;
        }

        /// <summary>
        /// remove the unwanted words from a presentation file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromPPT(string filePath, string[] wordsToRemove)
        {
            using (PresentationDocument presentationDocument = PresentationDocument.Open(filePath, false))
            {
                PresentationPart presentationPart = presentationDocument.PresentationPart;
                if (presentationPart != null)
                {
                    Presentation presentation = presentationPart.Presentation;

                    string text = "";
                    foreach (SlideId slideId in presentation.SlideIdList)
                    {
                        SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
                        if (slidePart != null)
                        {
                            Slide slide = slidePart.Slide;
                            text += GetSlideText(slide);
                        }
                    }
                    return text.Trim();
                }
            }
            return null;
            
        }
        private string GetSlideText(Slide slide)
        {
            string text = "";
            foreach (var element in slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>())
            {
                text += element.Text;
            }
            return text;
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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            string xmlString = xmlDoc.InnerText;
            return xmlString;
        }

        /// <summary>
        /// remove the unwanted words from XLS
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="wordsToRemove"></param>
        /// <returns></returns>
        private string RemoveWordsFromXLS(string filePath)
        {
            // Use a PDF processing library (e.g., iTextSharp, PdfSharp) to manipulate the PDF's content
            // Here, we'll simply return the file path for demonstration purposes
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            string xmlString = xmlDoc.InnerText;
            return xmlString;
        }
    }
}