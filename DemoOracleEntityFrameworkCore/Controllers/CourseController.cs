using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoOracleEntityFrameworkCore.Database;
using DemoOracleEntityFrameworkCore.Models;

namespace DemoOracleEntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CourseController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetActionAsync()
        {
            var courses = await _db.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdActionAsync(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> InsertActionAsync(CourseRequestParam course)
        {
            if (ModelState.IsValid)
            {
                Course c = new Course { CourseName = course.CourseName };
                _db.Courses.Add(c);
                await _db.SaveChangesAsync();
                return Ok(c);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActionAsync(int id, CourseRequestParam course)
        {
            if (ModelState.IsValid)
            {
                Course c = new Course { CourceId = id, CourseName = course.CourseName };
                try
                {
                    _db.Courses.Update(c);
                    await _db.SaveChangesAsync();
                    return Ok(c);
                }catch { }
            }
            return BadRequest();
        }
    }
}