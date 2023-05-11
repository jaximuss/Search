using Amazon.Runtime.Internal.Transform;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UISearcher
{
    public partial class ResultForm : Form
    {
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
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("documents");

            //Retrieve all documents from the collection and add them to a list
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();

            //Display each document in the list box
            foreach (var document in documents)
            {
                //get the file name of the document and add it to the listBox
                string fileName = Path.GetFileName(document["filename"].AsString);
                resultListbox.Items.Add(fileName);
                resultListbox.Items.Add(document.ToJson());

            }
        }
    }
}
