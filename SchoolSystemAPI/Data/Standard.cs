namespace SchoolSystemAPI.Data
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public string StandardDescription { get; set; }
        public List<Teacher> teachers { get; set;}
        public List<Student> Students { get; set; }
    }
}
