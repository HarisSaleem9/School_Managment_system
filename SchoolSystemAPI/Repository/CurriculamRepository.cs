using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;

namespace SchoolSystemAPI.Repository
{
    public class CurriculamRepository : ICurriculamRepository
    {
        private readonly DatabaseContext _context;

        public CurriculamRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Standard> AddStandardAsync(StandardDTO standard)
        {
            var newStandard = new Standard()
            {
                StandardName = standard.StandardName,
                StandardDescription = standard.StandardDescription
            };
            try { 
            _context.standards.Add(newStandard);
            await _context.SaveChangesAsync();
            return newStandard;
            }
            catch (Exception ex)
            {
                return null;
            }  
        }

        public async Task<Course> AddCoursesAsync(string name)
        {
            var newCourse = new Course()
            {
                Name = name
            };
            try { 
            
                _context.Courses.Add(newCourse);
                await _context.SaveChangesAsync();
                return newCourse;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Standard>> GetAllStandardsAsync()
        {
            var standards = await _context.standards.ToListAsync();
            return standards;
        }

        public async Task<Standard> GetStandardByIdWithTandS(int id)
        {
            var standard = await _context.standards
                .Include(s => s.Students)
                .Include(t => t.teachers)
                .FirstOrDefaultAsync(x => x.StandardId == id);
            return standard; 
        }

        public async Task<Course> GetCourseByIDAsyncs(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course == null)
            {
                return null;
            }
            return course;
        }

        public async Task<Course> UpdateCoursebyIdAsync(int id,string name)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return null;
            }
            course.Name = name;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }
        
        public async Task<string> DeleteCoursebyIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return null;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return "Record Deleted";
        }

        public async Task<Standard> GetStandardByIDAsync(int id)
        {
            var standard = await _context.standards.FindAsync(id);
            if (standard == null)
            {
                return null;
            }

            return standard;
        }

        public async Task<Standard> UpdateStandardbyIdAsync(UpdateStandardDTO request)
        {
            var standard = await _context.standards.FindAsync(request.StandardId);
            if (standard == null)
            {
                return null;
            }
            standard.StandardName = request.StandardName;
            standard.StandardDescription = request.StandardDescription;
            _context.standards.Update(standard);
            await _context.SaveChangesAsync();
            return standard;
        }

        public async Task<string> DeleteStandardbyIdAsync(int id)
        {
            var standard = await _context.standards.FindAsync(id);
            if (standard == null)
            {
                return null;
            }
            _context.standards.Remove(standard);
            await _context.SaveChangesAsync();
            return "Record Deleted";
        }
    }
}
