using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class TimeTable
    {
        [Key]
        public int TimeTableId { get; set; }
        public string CourseName { get; set; }
        public string LectureName {  get; set; } 
        public string Room {  get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
