using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_API_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student ( 1, "Paul", "Ochon",  new DateTime(1950, 12, 1) ),
            new Student ( 2, "Daisy", "Drathey", new DateTime(1970, 12, 1) ),
            new Student ( 3, "Elie", "Coptaire", new DateTime(1980, 12, 1) )
        };


        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> GetStudent()
        {
            return _students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            foreach (Student student in _students)
            {
                if (student.getId() == id)
                    return student;
            }
            return null;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void PutStudent(Student student)
        {
            var newStudent = new Student(student.getId(), student.getFirstName(), student.getLastName(), student.getBirthDate() );
            _students.Add(newStudent);

        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
