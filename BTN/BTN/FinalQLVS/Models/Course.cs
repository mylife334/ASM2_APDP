 using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Category { get; set; }

        public string CourseName { get; set; }
    }
}
