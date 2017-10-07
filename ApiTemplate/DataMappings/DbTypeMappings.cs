namespace ApiTemplate.DataMappings
{
    using DomainStudent = Models.Student;
    using DbStudent = ContosoUniversity.DAL.Models.Student;
    using DomainEnrollment = Models.Enrollment;
    using DbEnrollment = ContosoUniversity.DAL.Models.Enrollment;
    using DomainCourse = Models.Course;
    using DbCourse = ContosoUniversity.DAL.Models.Course;


    using System.Linq;
    using System.Collections.Generic;
    using System;

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
                ,Enrollments = new List<DomainEnrollment>(student.Enrollment.Select(e => e.MapToDomainType()))
            };
        }

        internal static DomainEnrollment MapToDomainType(this DbEnrollment enrollment)
        {
            Models.Grade? grade;
            if (enrollment.Grade.HasValue)
            {
                grade = (Models.Grade)enrollment.Grade.Value;
            }
            else
            {
                grade = null;
            }

            return new DomainEnrollment
            {
                EnrollmentId = enrollment.EnrollmentId
                ,CourseId = enrollment.CourseId
                ,Course = enrollment.Course.MapToDomainType()
                ,Grade = grade
                ,StudentId = enrollment.StudentId
            };
        }

        internal static DomainCourse MapToDomainType(this DbCourse course)
        {
            return new DomainCourse
            {
                CourseId = course.CourseId
                ,Credits = course.Credits
                ,Title = course.Title
                //,Enrollments = new List<DomainEnrollment>(course.Enrollment.Select(e => e.MapToDomainType()))
            };
        }


        internal static T ToEnum<T>(this string enumString)
        {
            // usage "A".ToEnum<Models.Grade>()
            return (T)Enum.Parse(typeof(T), enumString);
        }
    }
}
