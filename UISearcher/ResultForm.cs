using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using System.Diagnostics;
using System.Text;
using TikaOnDotNet.TextExtraction;

namespace UISearcher
{
    public partial class ResultForm : Form
    {
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

            Parser documentParser = new Parser();

            // Initialize the indexer
            Indexer indexer = new Indexer();

            //Display each document in the list box
            foreach (var document in documents)
            {
                //get the file name of the document and add it to the listBox
                string fileName = document["filename"].AsString;
                
                if (document.Contains("filepath"))
                {
                    string filePath = document["filepath"].AsString;
                    TextExtractionResult textContent = documentParser.ExtractTextFromDocument(filePath);
                    resultListbox.Items.Add(fileName);
                    resultListbox.Items.Add(document.ToJson());

                    // Index the document
                    string documentId = fileName; // Use a unique identifier for each document

                    indexer.IndexDocument(documentId, textContent.ToString());

                }
                resultListbox.Items.Add(fileName);
                resultListbox.Items.Add(collection.ToJson());

            }
            indexer.PrintInvertedIndex();

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

            //TODO - WE HAVE TO CHECK IF THE FILE IS A PDF OR TXT OR ANY OTHER TYPE
            // launch the file using the default application
            if (extension.ToLower() == ".txt")
            {
                Process.Start("notepad.exe", tempFile);
            }
            else if (extension.ToLower() == ".pdf")
            {
                Process.Start("notepad.exe", tempFile);

            }
        }


    }

}
