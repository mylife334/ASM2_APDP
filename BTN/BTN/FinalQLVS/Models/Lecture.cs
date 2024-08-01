using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }  
        
        [StringLength(10)]
        public string LectureCode { get; set; }
        public DateTime Startdate { get; set; }
        public string Specialized { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
