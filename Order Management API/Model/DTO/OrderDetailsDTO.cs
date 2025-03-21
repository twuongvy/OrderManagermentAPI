using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Order_Management_API.Model.DTO
{
    public class OrderDetailsDTO
    {
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Product name maximum 255 characters")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Quantity is require")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]

        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]

        public decimal Price { get; set; }

        
    }
}
