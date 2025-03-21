using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Order_Management_API.Model.DTO
{
    public class OrderDTO
    {
        [Required(ErrorMessage = "Customer name is require")]
        [StringLength(255, ErrorMessage = "Customer name maximum 255 characters")]
        public string CustomerName { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be greater or equals than 0.")]

        public decimal TotalAmount { get; set; }
        [Required]
        [Range(0, 2, ErrorMessage = "Invalid order status")]
        public int Status { get; set; } 
    }
}
