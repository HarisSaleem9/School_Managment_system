namespace SchoolSystemAPI.DTOs
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public int StandardID { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
