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

            //Display each document in the list box
            foreach (var document in documents)
            {
                //get the file name of the document and add it to the listBox
                string fileName = Path.GetFileName(document["filename"].AsString);
                resultListbox.Items.Add(fileName);

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
            var textContent = parser.RemoveWordsFromDocument(tempFile,wordsToRemove);

            MessageBox.Show(textContent);
            var indexingResult = indexing.IndexDocument(textContent);
            MessageBox.Show(indexingResult, "Word Counts");


            //TODO - WE HAVE TO CHECK IF THE FILE IS A PDF OR TXT OR ANY OTHER TYPE
            // launch the file using the default application
            //if (extension.ToLower() == ".txt")
            //{
            //    Process.Start("notepad.exe", tempFile);
            //}
            //else if (extension.ToLower() == ".pdf")
            //{
            //    Process.Start("notepad.exe", tempFile);

            //}
        }
    }
}   
