using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Management_API.Model
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        [Required]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    }
}
