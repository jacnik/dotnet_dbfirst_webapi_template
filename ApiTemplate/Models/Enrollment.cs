using Newtonsoft.Json;

namespace ApiTemplate.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        [JsonProperty("id")]
        public int EnrollmentId { get; set; }

        [JsonProperty("courseId")]
        public int CourseId { get; set; }

        [JsonProperty("grade")]
        public Grade? Grade { get; set; }

        [JsonProperty("StudentId")]
        public int StudentId { get; set; }

        [JsonProperty("course")]
        public Course Course { get; set; }

        [JsonProperty("student")]
        public Student Student { get; set; }
    }
}
