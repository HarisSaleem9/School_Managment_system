using System.Text.Json.Serialization;

namespace SchoolSystemAPI.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int StandardID { get; set; }
        [JsonIgnore]
        public Standard Standard { get; set; }
        [JsonIgnore]
        public StudentAddress StudentAddress { get; set; }
        public List<Course> Courses { get; set; }
    }
}
