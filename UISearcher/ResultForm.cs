using Amazon.Runtime.Internal.Transform;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISearcher;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using org.apache.poi.util;

namespace UISearcher
{
    public partial class ResultForm : Form
    {
        Indexer indexing = new Indexer();

        string[] wordsToRemove = { "a", "an", "the", "of", "in", "on", "at", "to", "for", "with", "and", "or", "but", "is", "are",
            "was", "were", "has", "have", "had", "be", "been", "being", "it", "that", "this", "these", "those", "as", "from", "by",
            "about", "into", "through", "over", "under", "above", "below", "between", "among", "while", "during", "before", "after",
            "since", "until", "unless", "although", "though", "even", "if", "unless", "not", "nor", "yet", "so", "because",
            "since", "due", "both", "either", "neither", "whether", "where", "when", "who", "whom", "which", "what", "whose", "how" };

        private IMongoCollection<BsonDocument> collection;
        private string Query;
        public ResultForm(string query)
        {
            Query = query;

            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            //show document
            //Get a reference to the database
            IMongoDatabase database = client.GetDatabase("Test");

            //Get a reference to the collection
            //using the class level of imongocollection
            collection = database.GetCollection<BsonDocument>("documents");

            //Retrieve all documents from the collection and add them to a list
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();

            // Initialize the document scores dictionary
            Dictionary<string, int> documentScores = new Dictionary<string, int>();

            // intialize the parser class to use the extract method
            Parser parser = new Parser(collection);

            if (!String.IsNullOrEmpty(Query))
            {


                // Iterate through the documents and calculate the scores
                foreach (var document in documents)
                {
                    string filename = Path.GetFileName(document["filename"].AsString);
                    var contentBytes = document["content"].AsByteArray;
                    var extension = Path.GetExtension(document["filename"].AsString);
                    var tempFile = Path.GetTempFileName() + extension;
                    File.WriteAllBytes(tempFile, contentBytes);
                    var textContent = parser.RemoveWordsFromDocument(tempFile, wordsToRemove);
                    var indexer = new Indexer();
                    string indexedDocument = indexer.IndexDocument(textContent);

                    if (indexedDocument.Contains(Query))
                    {
                        // Calculate the score based on word count
                        int score = indexedDocument.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Where(line => line.Contains(Query))
                                                  .Sum(line => int.Parse(line.Split(':')[1].Trim()));

                        documentScores[filename] = score;
                    }
                    // Delete the temporary file after processing each document
                    File.Delete(tempFile);
                }

                // Sort the documents based on their scores in descending order
                var sortedDocuments = documentScores.OrderByDescending(pair => pair.Value);

                // Display the sorted documents to the user
                foreach (var document in sortedDocuments)
                {
                    resultListbox.Items.Add(document.Key);
                }
            }
            else
            {
                MessageBox.Show("your search box is empty");
            }
        }

        private void resultListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // retrieve the selected filename
            var filename = resultListbox.SelectedItem.ToString();

            // find the document with the selected filename
            var filter = Builders<BsonDocument>.Filter.Eq("filename", filename);
            var document = collection.Find(filter).FirstOrDefault();

            // get the content of the document and display it in a textbox
            var contentBytes = document["content"].AsByteArray;
            var contentString = Encoding.UTF8.GetString(contentBytes);
            var extension = Path.GetExtension(document["filename"].AsString);
            var tempFile = Path.GetTempFileName() + extension;
            File.WriteAllBytes(tempFile, contentBytes);


            // intialize the parser class to use the extract method
            Parser parser = new Parser(collection);


            //EXTRACT TEXT FROM DOCUMENT
            var textContent = parser.RemoveWordsFromDocument(tempFile, wordsToRemove);

            MessageBox.Show(textContent);

        }

        public void ClearResults()
        {
            resultListbox.Items.Clear();
        }
        public void AddResult(string fileName)
        {
            resultListbox.Items.Add(fileName);
        }

    }
}
