namespace ApiTemplate.SchoolModel
{
    using ApiTemplate.SchoolModel.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISchoolRepository
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);
    }
}
