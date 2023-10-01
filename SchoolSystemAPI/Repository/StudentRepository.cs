using Microsoft.EntityFrameworkCore;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;

namespace SchoolSystemAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _studentContext;

        public StudentRepository(DatabaseContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Student> AddStudentAsync(StudentDTO student)
        {
            var address = new StudentAddress()
            {
                Address1 = student.Address1,
                Address2 = student.Address2,
                State = student.State,
                City = student.City,
            };

            var newStudent = new Student()
            {
                Name = student.Name,
                StandardID = student.StandardID,
                StudentAddress = address
            };
            _studentContext.Students.Add(newStudent);
            await _studentContext.SaveChangesAsync();
            return newStudent;
        }

        public async Task<Student> AddStudentCourseAsync(StudentsCourseDTO request)
        {
            var student = await _studentContext.Students
                .Where(s=>s.StudentId == request.StudentId)
                .Include(c=>c.Courses)
                .FirstOrDefaultAsync();
            if(student == null)
            {
                return null;
            }
            var course = await _studentContext.Courses.FindAsync(request.CourseId);
            if(course == null)
            {
                return null;
            }
            student.Courses.Add(course);
            await _studentContext.SaveChangesAsync();
            return student;
            
        }
        public async Task<List<Student>> GetAllStudentAsync()
        {
            var student = await _studentContext.Students.Include(c => c.Courses).ToListAsync(); 
            return student;
        }

        public async Task<Student> UpdateStudentbyIdAsync(UpdateStudentDTO request)
        {
            var student = await _studentContext.Students.FindAsync(request.StudentId);
            var address = await _studentContext.StudentAddresses.FindAsync(request.StudentId);
            address.Address1 = request.Address1;
            address.Address2 = request.Address2;
            address.State = request.State;
            address.City = request.City;
            student.Name = request.Name;
            student.StandardID = request.StandardID;
            _studentContext.Students.Update(student);
            _studentContext.StudentAddresses.Update(address);
            await _studentContext.SaveChangesAsync();
            return student;

        }

        public async Task<StudentAddress> GetStudentAddressAsync(int id) 
        {
            return await _studentContext.StudentAddresses.FindAsync(id);
        }

        public async Task<string> DeleteStudentAsync(int id)
        {
            var result = await _studentContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (result != null)
            {
                _studentContext.Students.Remove(result);
                await _studentContext.SaveChangesAsync();
                return "Record Deleted";
            }
            return "Not Found";
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentContext.Students.Include(c => c.Courses).FirstOrDefaultAsync(x => x.StudentId == id);
            if (student  != null)
            {
                return student;
            }
            return null;
        }
        
    }
}
