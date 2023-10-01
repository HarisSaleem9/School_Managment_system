using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;

namespace SchoolSystemAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DatabaseContext _context;

        public TeacherRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Teacher> AddTeacherAsync(TeacherDTO teacher)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == teacher.CourseId);
            if (course == null )
            {
                return null;
            }
            var newTeacher = new Teacher()
            {
                TeacherName = teacher.TeacherName,
                TeacherType = teacher.TeacherType,
                StandardId = teacher.StandardId,
                Course = course
            };
            try
            {

                _context.Teachers.Add(newTeacher);
                await _context.SaveChangesAsync();
                return newTeacher;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            return await _context.Teachers.Include(c=>c.Course).ToListAsync();
        }

        public async Task<string> DeleteTeacherByIDAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return "Wrong Id";
            }
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return "Recod Deleted";
        }

        public async Task<Teacher> UpdateTeacherAsync(UpdateTeacherDTO request)
        {
            var teacher = await _context.Teachers.Include(c => c.Course).FirstOrDefaultAsync(x=>x.TeacherId == request.TeacherId);
            var course = await _context.Courses.FindAsync(request.CourseId);

            teacher.TeacherName = request.TeacherName;
            teacher.TeacherType = request.TeacherType;
            teacher.StandardId = request.StandardId;
            teacher.Course = course;
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
