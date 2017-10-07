namespace ApiTemplate.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Student
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("enrollmentDate")]
        public DateTime EnrollmentDate { get; set; }

        [JsonProperty("firstName")]
        public string FirstMidName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("enrollments")]
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
