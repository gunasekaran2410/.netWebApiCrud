using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("attendance")]
    public class AttendanceModel
    {
        internal object studentId;

        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string AttendanceId { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentModel student_table { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string SectionId { get; set; }

        [ForeignKey("SectionId")]
        public SectionModel section_table { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateAttended { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Hours { get; set; }
    }
}
