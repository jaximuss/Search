using Microsoft.AspNetCore.Mvc;

namespace Search.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>()
        {
            new Student() {CGPA = 5.0f , Name = "jaximus dowing" , Department = "computer science", Faculty ="science" , MatricNumber ="180813024"},
            new Student() {CGPA = 4.35f , Name = "precious" , Department = "chemistry", Faculty ="science" , MatricNumber = "180802500"},
            new Student() {CGPA = 2.2f , Name = "dowing" , Department = "marine science", Faculty ="science" , MatricNumber = "180805002"},
            new Student() {CGPA = 3.2f, Name = "emeka" , Department = "physics", Faculty ="science" , MatricNumber = "180805027"},
            new Student() {CGPA = 1.5f, Name = "joseph ebuka" , Department = "fisherey", Faculty ="science" , MatricNumber = "180805024"}
        };
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return students;
        }

        [HttpGet("{MatricNumber}")]
        public Student GetStudent(string matricNumber)
        {
            return students.Find(p => p.MatricNumber == matricNumber);
        }

    }
}
