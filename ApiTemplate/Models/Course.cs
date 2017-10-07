namespace ApiTemplate.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Course
    {
        [JsonProperty("id")]
        public int CourseId { get; set; }

        [JsonProperty("credits")]
        public int Credits { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("enrollments")]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
