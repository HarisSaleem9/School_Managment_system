namespace SchoolSystemAPI.DTOs
{
    public class UpdateTeacherDTO
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int StandardId { get; set; }
        public string TeacherType { get; set; }
        public int CourseId { get; set; }
    }
}
