using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoOracleEntityFrameworkCore.Database;
using DemoOracleEntityFrameworkCore.Models;

namespace DemoOracleEntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionAsync()
        {
            var students = await _db.Students.Include(s => s.Course).ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdActionAsync(int id)
        {
            var student = await _db.Students.Where(s => s.StudentId == id)
            .Include(s => s.Course)
            .FirstOrDefaultAsync();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> InsertActionAsync(StudentRequestParam student)
        {
            if (ModelState.IsValid)
            {
                Student s = new Student
                {
                    CourseId = student.CourseId,
                    StudentFirstName = student.StudentFirstName,
                    StudentLastName = student.StudentLastName,
                    StudentEmail = student.StudentEmail,
                    StudentBirthday = student.StudentBirthday,
                    StudentGender = student.StudentGender
                };
                try
                {
                    _db.Students.Add(s);
                    await _db.SaveChangesAsync();
                    return Ok(s);
                }catch { }
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActionAsync(int id, StudentRequestParam student)
        {
            if (ModelState.IsValid)
            {
                Student s = new Student
                {
                    StudentId = id,
                    CourseId = student.CourseId,
                    StudentFirstName = student.StudentFirstName,
                    StudentLastName = student.StudentLastName,
                    StudentEmail = student.StudentEmail,
                    StudentBirthday = student.StudentBirthday,
                    StudentGender = student.StudentGender
                };
                try
                {
                    _db.Students.Update(s);
                    await _db.SaveChangesAsync();
                    return Ok(s);
                }catch { }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActionAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
                return Ok(student);
            }
            return BadRequest();
        }
    }
}