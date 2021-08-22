using System;

namespace DemoOracleEntityFrameworkCore.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public DateTime StudentBirthday { get; set; }
        public bool? StudentGender { get; set; }
        public string StudentEmail { get; set; }
        public virtual Course Course { get; set; }
    }
}