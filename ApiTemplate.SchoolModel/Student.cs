namespace ApiTemplate.SchoolModel
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
