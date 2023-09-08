using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    public class SectionModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string SectionId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string CourseId { get; set; }
        [ForeignKey("CourseId")]
        public CourseModel course_table { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        public ScheduleModel schedule_table { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public InstructorModel instructor_table { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Room { get; set; }

        

        




    }
}
