using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("course")]
    public class CourseModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string CourseId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Description { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Type { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public int Term { get; set; }
    }
}
