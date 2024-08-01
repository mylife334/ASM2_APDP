using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class SubjectCourse
    {
        [Key]
        public int SubjectCourseId { get; set; }
        public string Category { get; set; }
        public string CourseName { get; set; }
        public string NameStudent { get; set; }
        public string lecturer { get; set; }
        public string point {  get; set; }
        public string Status { get; set; }
    }
}
