using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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


        }

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

        private void searchButton_Click(object sender, EventArgs e)
        {
            string query = searchtexbox.Text;
            ResultForm result = new ResultForm(query);
            result.Show();
        }

        private void parsed_Click(object sender, EventArgs e)
        {

        }
    }
    //TODO - PARSER AND COLLECT THE DOCUMENT BACK FROM THE DB
    //TODO - DISPLAY THE DOCUMENT
    //TODO - MAKE THE DOCUMENT CLICKABLE
    //TODO - CREATE AN INDEXER FROM SCRATCH
    //TODO - MAKE RANKING SYSTEM
    //TODO - CLEAN UP THE CODE AND MAKE SEPERATE CLASSES AND FUNCTIONS FOR EACH TASK ALSO REMOVE THE STUDENT NONSENSE
    //TODO - SUMMARIES MUST BE MADE FOR EACH FUNCTION AND CLASS SO AS TO MAKE PROPER DOCUMENTATION
    //TODO - MAKE A PROPER UI
    //TODO - RUN NUNIT TESTS
    //TODO - GET AUTO COMPLETE WORKING

}