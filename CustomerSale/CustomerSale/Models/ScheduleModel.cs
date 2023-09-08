using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("schedule")]
    public class ScheduleModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string ScheduleId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public DateTime Day { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string StartTime { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string EndTime { get; set; }
    }
}
