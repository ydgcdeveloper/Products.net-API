using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Server.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} should have {1} characters maximum")]
        public string Name { get; set; } = null;

        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "The field {0} should have {1} characters maximum")]
        public string Description { get; set; } = null;

        [Column(TypeName ="decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }
    }
}
