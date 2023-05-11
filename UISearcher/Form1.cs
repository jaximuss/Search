using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Search;
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
            ResultForm result =new ResultForm(query);
            result.Show();
        }
    }
}