using System.ComponentModel.DataAnnotations;

namespace FinalQLVS.Models
{
    public class NoticeClass
    {
        [Key]
        public int NoticeCId { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
