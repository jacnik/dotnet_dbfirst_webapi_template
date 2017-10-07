namespace ApiTemplate.Repositories
{
    using ApiTemplate.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISchoolRepository
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task<int?> AddStudent(Student student);
    }
}
