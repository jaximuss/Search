using UISearcher;

namespace searchEngineTestingGrounds
{
    public class ParserTests
    {
        [TestMethod]
        public void TestRemoveWordsFromTextFileDocument()
        {

            // Arrange
            var cleanedText = new Parser();
            string filePath = "testfile.txt";
            string originalText = "The quick brown fox jumps over the lazy dog.";
            string expectedText = "quick brown jumps over lazy";
            // Write the original text to a file
            File.WriteAllText(filePath, originalText);

            // Act
            cleanedText = RemoveWordsFromTextFile(filePath);

            // Assert
            Assert.AreEqual(expectedText, cleanedText);

        }
        [TestMethod]
        public void TestRemoveWordsFromWordDocument()
        {
            //Arrange
            var parse1 = new Parser();

            //Act
            var result = parse1.RemoveWordsFromWordDocument(filePath, wordsToRemove);

            // Assert
            Assert.AreEqual(filePath, result);


        }
        [TestMethod]
        public void TestRemoveWordsFromPdf()
        {
            //Arrange
            var parse2 = new Parser();

            //Act
            var result = parse2.RemoveWordsFromPdf(filepath, wordsToRemove);

            //Assert
            Assert.IsFalse(result.Contains("either"));
            Assert.IsFalse(result.Contains("over"));
            Assert.IsFalse(result.Contains("though"));
        }
        [TestMethod]
        public void TestRemoveWordsFromHTML()
        {
            //Arrange
            var parse3 = new Parser();

            //Act
            var result1 = parse3.RemoveWordsFromHTML(filepath, wordsToRemove);

            //Assert
            Assert.IsTrue(result1.Contains("over"));
            Assert.IsTrue(result1.Contains("through"));
            Assert.IsTrue(result1.Contains("either"));
        }
        [TestMethod]
        public void TestRemoveWordsFromPPTL()
        {
            //Arrange
            var parse4 = new Parser();

            //Act
            var result2 = parse4.RemoveWordsFromPPT(filepath, wordsToRemove);

            //Assert
            Assert.IsTrue(result1.Contains("over"));
            Assert.IsTrue(result1.Contains("through"));
            Assert.IsTrue(result1.Contains("either"));
        }
        [TestMethod]
        public void TestRemoveWordsFromXML()
        {
            //Arrange
            var parse5 = new Parser();

            //Act
            var result3 = parse5.RemoveWordsFromXML(filepath, wordsToRemove);

            //Assert
            Assert.IsTrue(result1.Contains("neither"));
            Assert.IsTrue(result1.Contains("either"));
            Assert.IsTrue(result1.Contains("over"));

        }
        [TestMethod]
        public void TestRemoveWordsFromXLS()
        {
            //Arrange
            var parse6 = new Parser();

            //Act
            var result4 = parse6.RemoveWordsFromXLS(filepath, wordsToRemove);

            //Assert
            Assert.IsTrue(result1.Contains("over"));
            Assert.IsTrue(result1.Contains("either"));
            Assert.IsTrue(result1.Contains("through"));


        }
    }
}
