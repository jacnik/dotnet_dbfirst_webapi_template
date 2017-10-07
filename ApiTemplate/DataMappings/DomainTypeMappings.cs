namespace ApiTemplate.DataMappings
{
    using DomainStudent = Models.Student;
    using DbStudent = ContosoUniversity.DAL.Models.Student;

    internal static class DomainTypeMappings
    {
        internal static DbStudent MapToDbType(this DomainStudent student)
        {
            return new DbStudent
            {
                Id = student.Id
                ,LastName = student.LastName
                ,FirstMidName = student.FirstMidName
                ,EnrollmentDate = student.EnrollmentDate
                //,Enrollment = student.Enrollment // todo map Enrollment to DbType
            };
        }
    }
}
