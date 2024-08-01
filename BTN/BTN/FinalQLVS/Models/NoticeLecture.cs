using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class NoticeLecture
    {
        [Key]
        public int NoticeLId { get; set; }
        public string LectureCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
