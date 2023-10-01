using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;

namespace SchoolSystemAPI.Repository
{
    public interface ICurriculamRepository
    {
        Task<Standard> AddStandardAsync(StandardDTO standard);
        Task<Course> AddCoursesAsync(string name);
        Task<List<Course>> GetCoursesAsync();
        Task<List<Standard>> GetAllStandardsAsync();
        Task<Standard> GetStandardByIdWithTandS(int id);
        Task<Course> GetCourseByIDAsyncs(int id);
        Task<Course> UpdateCoursebyIdAsync(int id, string name);
        Task<string> DeleteCoursebyIdAsync(int id);
        Task<Standard> GetStandardByIDAsync(int id);
        Task<Standard> UpdateStandardbyIdAsync(UpdateStandardDTO request);
        Task<string> DeleteStandardbyIdAsync(int id);
    }
}
