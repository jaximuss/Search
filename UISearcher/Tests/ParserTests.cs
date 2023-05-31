using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISearcher.Tests
{
    [TestFixture]
    public class ParserTests :Parser
    {
        private Parser parser;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the Parser class
            // You may need to provide the required dependencies (e.g., the MongoDB collection) for the constructor
            // For demonstration purposes, let's assume no dependencies are required
            parser = new Parser();
        }

        [Test]
        public void RemoveWordsFromTextFile_ValidFile_ReturnsCleanedText()
        {
            // Arrange
            string filePath = "path_to_sample_text_file.txt";
            string expectedCleanedText = "Sample cleaned text without unwanted words.";

            // Act
            string cleanedText = parser.RemoveWordsFromTextFile(filePath);

            // Assert
            Assert.AreEqual(expectedCleanedText, cleanedText);
        }

        [Test]
        public void RemoveWordsFromWordDocument_ValidDocument_ReturnsCleanedText()
        {
            // Arrange
            string filePath = "path_to_sample_word_document.docx";
            string[] wordsToRemove = { "a", "an", "the", "of", "in", "on", "at", "to", "for", "with", "and", "or", "but", "is", "are",
            "was", "were", "has", "have", "had", "be", "been", "being", "it", "that", "this", "these", "those", "as", "from", "by",
            "about", "into", "through", "over", "under", "above", "below", "between", "among", "while", "during", "before", "after",
            "since", "until", "unless", "although", "though", "even", "if", "unless", "not", "nor", "yet", "so", "because",
            "since", "due", "both", "either", "neither", "whether", "where", "when", "who", "whom", "which", "what", "whose", "how" };
            string expectedCleanedText = "Sample cleaned text from Word document.";

            // Act
            string cleanedText = parser.RemoveWordsFromWordDocument(filePath);

            // Assert
            Assert.AreEqual(expectedCleanedText, cleanedText);
        }

        [Test]
        public void RemoveWordsFromPdf_ValidPdf_ReturnsCleanedText()
        {
            // Arrange
            string filePath = "path_to_sample_pdf.pdf";
            string[] wordsToRemove = { "unwanted", "words" };
            string expectedCleanedText = "Sample cleaned text from PDF.";

            // Act
            string cleanedText = parser.RemoveWordsFromPdf(filePath);

            // Assert
            Assert.AreEqual(expectedCleanedText, cleanedText);
        }

        // Write similar test methods for other document formats supported by the Parser class

        // Add more test methods to cover different scenarios and edge cases

    }
}
