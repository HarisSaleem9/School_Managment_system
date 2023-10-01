using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;

namespace SchoolSystemAPI.Repository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(StudentDTO student);
        Task<Student> AddStudentCourseAsync(StudentsCourseDTO request);
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> UpdateStudentbyIdAsync(UpdateStudentDTO request);
        Task<StudentAddress> GetStudentAddressAsync(int id);
        Task<string> DeleteStudentAsync(int id);
        Task<Student> GetStudentByIdAsync(int id);
    }
}
