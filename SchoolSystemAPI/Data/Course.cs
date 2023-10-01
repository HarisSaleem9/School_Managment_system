using System.Text.Json.Serialization;

namespace SchoolSystemAPI.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Teacher> Teachers { get; set;}
        [JsonIgnore]
        public List<Student> Students { get; set; }
    }
}
