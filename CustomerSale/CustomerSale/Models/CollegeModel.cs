using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSale.Models
{
    [Table("college")]
    public class CollegeModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string CollegeId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string Name { get; set; }

    }
}
