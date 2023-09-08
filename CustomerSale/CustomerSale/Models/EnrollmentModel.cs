using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("enrollment")]
    public class EnrollmentModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string EnrollmentId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string AcademicYear { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Term { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string DateEnrolled { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentModel student_table { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string SectionId { get; set; }

        [ForeignKey("SectionId")]
        public SectionModel section_table { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public int MidtermGrade { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public int FinalGrade { get; set; }
    }
}
