using ApiTemplate.ContosoUniversity.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTemplate.ContosoUniversity.DAL
{
    public class ContosoRepository : ISchoolRepository
    {
        /*
         * Models folder was generated using the following command:
         * dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=ContosoUniversity1;Trusted_Connection=True;MultipleActiveResultSets=true" -o Models Microsoft.EntityFrameworkCore.SqlServer -c "SchoolContext" -f
         */

        private readonly SchoolContext context;

        public ContosoRepository(SchoolContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await this.context.Student.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await this.context.Student
                .Include(s => s.Enrollment)
                    .ThenInclude(e => e.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            return student;
        }
    }
}
