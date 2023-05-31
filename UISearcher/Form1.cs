using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace UISearcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the autocomplete data
            List<string> autoCompleteData = LoadAutoCompleteData();

            // Set the autocomplete mode and source for the searchtextbox control
            searchtexbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            searchtexbox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Create a new AutoCompleteStringCollection and populate it with the autocomplete data
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(autoCompleteData.ToArray());

            // Set the AutoCompleteCustomSource for the searchtextbox control
            searchtexbox.AutoCompleteCustomSource = autoCompleteCollection;
        }

        /// <summary>
        /// this is the upload document button that will upload the document to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Create a new instance of openfile dialog
            OpenFileDialog uploadDocument = new OpenFileDialog();

            // Set the file filter to allow only pdf, doc, docx, ppt, ppts, xls, xlsx, txt, html and xml files
            this.uploadDocument.Filter = "PDF and Document Files|*.pdf;*.doc;*.docx;*.ppt;*.pptx;*.xls;*.xlsx;*.txt;*.html;*.xml";

            // Set the initial directory that you want the file manager to open
            this.uploadDocument.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Show the dialog box and get the result
            DialogResult result = this.uploadDocument.ShowDialog();

            // If the user clicked OK, get the file name and path and store it in a variable
            if (result == DialogResult.OK)
            {
                MessageBox.Show("File uploaded successfully");
                string fileName = this.uploadDocument.FileName;

                // Read the file into a byte array
                byte[] fileData = File.ReadAllBytes(fileName);

                // Create a new instance of the MongoClient class
                MongoClient client = new MongoClient("mongodb://localhost:27017");

                // Get a reference to the database
                IMongoDatabase database = client.GetDatabase("Test");

                // Get a reference to the collection
                IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("documents");

                // Create a new document with the file data
                var document = new BsonDocument
                {
                    { "filename", Path.GetFileName(fileName) },
                    { "content", new BsonBinaryData(fileData) }
                };

                // Insert the document into the collection
                collection.InsertOne(document);
            }
        }

        /// <summary>
        /// loads up the result page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            string query = searchtexbox.Text;
            MeasureQuerySearchTime(query);

            ResultForm result = new ResultForm(query);
        }

        private void parsed_Click(object sender, EventArgs e)
        {

        }

        private void searchtexbox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// load the autocomplete property of the search box get each word from the mongodb database and display it to the user
        /// </summary>
        /// <returns></returns>
        private List<string> LoadAutoCompleteData()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Test");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("documents");

            List<string> autoCompleteData = new List<string>();

            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Include("content");
            var documents = collection.Find(filter).Project(projection).ToList();

            foreach (var document in documents)
            {
                var contentBytes = document["content"].AsByteArray;
                var contentString = Encoding.UTF8.GetString(contentBytes);
                var words = contentString.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                autoCompleteData.AddRange(words);
            }

            return autoCompleteData;
        }

        private void MeasureQuerySearchTime(string query)
        {
            // Start the stopwatch to measure the query search time
            Stopwatch stopwatch = Stopwatch.StartNew();

            ResultForm result = new ResultForm(query);
            result.Show();

            // Stop the stopwatch and calculate the elapsed time in seconds
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            double seconds = Math.Round(elapsedTime.TotalSeconds/10,3 );

            // Display the query search time in seconds
            MessageBox.Show($"Query search time: {seconds} seconds");
        }
    }

}