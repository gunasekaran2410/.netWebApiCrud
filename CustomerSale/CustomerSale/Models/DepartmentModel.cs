using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("department")]
    public class DepartmentModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string DepartmentId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string ChairId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string ContactPhone { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string ContactEmail { get; set; }
    }
}
