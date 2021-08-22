using System.ComponentModel.DataAnnotations;

namespace DemoOracleEntityFrameworkCore.Models
{
    public class CourseRequestParam
    {
        [Required]
        public string CourseName { get; set; }
    }
}