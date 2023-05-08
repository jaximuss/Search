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

        private async void button1_Click(object sender, EventArgs e)
        {
            
            string matricNumber = matrictextbox.Text;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7141/api/student");
                var responseTask = client.GetAsync($"/student/{matricNumber}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var student = JsonConvert.DeserializeObject<Student>(readTask.Result);

                    Namelabel.Text = $"Name: {student.Name}";
                    departmentLabel.Text = $"Department: {student.Department}";
                    facultylabel.Text = $"Faculty: {student.Faculty}";
                    cgpaLabel.Text = $"CGPA: {student.CGPA}";
                }
            }
        }
    }
}