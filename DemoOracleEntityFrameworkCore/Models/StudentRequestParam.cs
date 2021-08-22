using System;
using System.ComponentModel.DataAnnotations;

namespace DemoOracleEntityFrameworkCore.Models
{
    public class StudentRequestParam
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string StudentFirstName { get; set; }
        [Required]
        public string StudentLastName { get; set; }
        [Required]
        public DateTime StudentBirthday { get; set; }
        public bool? StudentGender { get; set; }
        [Required]
        public string StudentEmail { get; set; }
    }
}