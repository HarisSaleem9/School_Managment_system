using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolSystemAPI.Data
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int StandardId { get; set; }
        [JsonIgnore]
        public Standard Standard { get; set; }
        public string TeacherType { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}
