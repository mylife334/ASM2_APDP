using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        [StringLength(10)]

        public string StudentCode { get; set; }
        public DateTime Startdate { get; set; }

        [StringLength(10)]
        public string StudentCls { get; set; }
        public string Specialized {  get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        public string Password { get; set; }
    }
}
