namespace ApiTemplate.SchoolModel.DataMappings
{
    using DomainStudent = Models.Student;
    using DbStudent = ContosoUniversity.DAL.Models.Student;

    internal static class DbTypeMappings
    {
        internal static DomainStudent MapToDomainType(this DbStudent student)
        {
            return new DomainStudent
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
