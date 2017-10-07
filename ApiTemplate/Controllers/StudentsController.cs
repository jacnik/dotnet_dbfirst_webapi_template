namespace ApiTemplate.Controllers
{
    using ApiTemplate.ContosoUniversity.DAL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly ISchoolRepository repository;

        public StudentsController(ISchoolRepository repository)
        {
            this.repository = repository;
        }

        // GET api/students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await this.repository.GetStudents();
            return Ok(students);
        }
        
        // GET api/students
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await this.repository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
    }
}
