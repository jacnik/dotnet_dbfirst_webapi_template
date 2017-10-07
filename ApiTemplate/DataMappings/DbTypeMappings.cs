namespace ApiTemplate.DataMappings
{
    using DomainStudent = Models.Student;
    using DbStudent = ContosoUniversity.DAL.Models.Student;
    using DomainEnrollment = Models.Enrollment;
    using DbEnrollment = ContosoUniversity.DAL.Models.Enrollment;
    using System.Linq;

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
                ,Enrollments = student.Enrollment.Select(e => e.MapToDomainType())
            };
        }

        internal static DomainEnrollment MapToDomainType(this DbEnrollment enrollment)
        {
            return new DomainEnrollment
            {
                EnrollmentId = enrollment.EnrollmentId
                ,CourseId = enrollment.CourseId
                //,Course = enrollment.Course
                //,Grade = Models.Grade
                ,StudentId = enrollment.StudentId
            };
        }
    }
}
