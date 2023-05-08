using Microsoft.AspNetCore.Mvc;

namespace Search.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private List<Person> persons = new List<Person>
        {
            new Person { ID = 1, Name = "John Doe", Email = "johndoe@example.com", PhoneNumber = "123-456-7890", Sex = "Male", Address = "123 Main St." },
            new Person { ID = 2, Name = "Jane Smith", Email = "janesmith@example.com", PhoneNumber = "987-654-3210", Sex = "Female", Address = "456 Elm St." },
            new Person { ID = 3, Name = "Bob Johnson", Email = "bobjohnson@example.com", PhoneNumber = "555-555-1212", Sex = "Male", Address = "789 Oak St." }
        };

        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return persons;
        }

        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            return persons.Find(p => p.ID == id);
        }
    }
}
