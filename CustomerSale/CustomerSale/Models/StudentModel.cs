using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("student")]
    public class StudentModel
    {
        internal object studentId;

        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string StudentId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string LastName { get; set; }
        [Column(TypeName = "Varchar(150)")]
        public string Firstname { get; set; }
        [Column(TypeName = "Varchar(150)")]
        public string Contact { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string CollegeId { get; set; }

        [ForeignKey("CollegeId")]
        public CollegeModel college_table { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Email { get; set; }
    }
}
