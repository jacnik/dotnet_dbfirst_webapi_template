namespace ApiTemplate
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApiTemplate.DataMappings;
    using ApiTemplate.Models;
    using ApiTemplate.ContosoUniversity.DAL;
    using System.Linq;

    public class SchoolRepository : ISchoolRepository
    {
        private ContosoRepository repository;

        public SchoolRepository(ContosoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Student> GetStudent(int id)
        {
            var dbStudent = await this.repository.GetStudent(id);
            return dbStudent?.MapToDomainType();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var dbStudents = await this.repository.GetStudents();
            return dbStudents?.Select(s => s.MapToDomainType());
        }
    }
}
