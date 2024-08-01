using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FinalQLVS.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string NameStaff { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string StaffCode {  get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
