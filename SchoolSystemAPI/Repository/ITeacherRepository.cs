using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;

namespace SchoolSystemAPI.Repository
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacherAsync(TeacherDTO teacher);
        Task<List<Teacher>> GetAllTeacherAsync();
        Task<string> DeleteTeacherByIDAsync(int id);
        Task<Teacher> UpdateTeacherAsync(UpdateTeacherDTO request);
    }
}
