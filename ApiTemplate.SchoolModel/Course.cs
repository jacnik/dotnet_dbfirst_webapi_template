namespace ApiTemplate.SchoolModel
{
    using System.Collections.Generic;

    public class Course
    {
        public int CourseId { get; set; }
        public int Credits { get; set; }
        public string Title { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
