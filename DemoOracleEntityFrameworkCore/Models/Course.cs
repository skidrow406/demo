using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DemoOracleEntityFrameworkCore.Models
{
    public class Course
    {
        public Course() {
            Students = new HashSet<Student>();
        }
        public int CourceId { get; set; }
        public string CourseName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students {get;set;}
    }
}