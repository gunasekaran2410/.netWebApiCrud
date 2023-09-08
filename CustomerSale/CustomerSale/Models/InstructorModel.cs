using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("instructor")]
    public class InstructorModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string InstructorId { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string CollegeId { get; set; }

        [ForeignKey("CollegeId")]
        public CollegeModel college_table { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Rank { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public int Type { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public DepartmentModel department_table { get; set; }

    }
}
