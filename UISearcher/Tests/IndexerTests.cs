using NUnit.Framework;
using UISearcher;


namespace UISearcher.Tests
{
    public class IndexerTests
    {
        [TestMethod]
        public void IndexDocument_ReturnsCorrectWordCountString()
        {
            // Arrange
            string document = "The quick brown fox jumps over the lazy dog. The dog then jumps over the fox.";
            string expectedOutput = "The: 2\r\nquick: 1\r\nbrown: 1\r\nfox: 2\r\njumps: 2\r\nover: 2\r\nthe: 2\r\nlazy: 1\r\ndog.: 1\r\nthen: 1\r\n";
            // Act
            string output = IndexDocument(document);

            // Assert
            Assert.AreEqual(expectedOutput, output);

        }
       
         [TestMethod]
        public void RemoveSpecialCharacters_ValidWord_ReturnsCleanedWord()
            {
                // Arrange
                string word = "Hello, World!";
                string expectedCleanedWord = "hello world";

                // Create an instance of the Indexer class
                Indexer indexer = new Indexer();

                // Act
                string cleanedWord = indexer.RemoveSpecialCharacters(word);

                // Assert
                Assert.AreEqual(expectedCleanedWord, cleanedWord);
            }

        [TestMethod]
        public void RemoveSpecialCharacters_WordWithSpecialCharacters_ReturnsCleanedWord()
            {
                // Arrange
                string word = "#Test123!@";
                string expectedCleanedWord = "test123";

                // Create an instance of the Indexer class
                indexer indexer1  = new Parser();

                // Act
                string cleanedWord = indexer1.RemoveSpecialCharacters(word);

                // Assert
                Assert.AreEqual(expectedCleanedWord, cleanedWord);
            }

        }
    }

}
