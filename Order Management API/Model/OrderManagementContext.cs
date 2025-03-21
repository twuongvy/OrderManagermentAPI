using Microsoft.EntityFrameworkCore;

namespace Order_Management_API.Model
{
    public class OrderManagementContext: DbContext
    {
        public OrderManagementContext(DbContextOptions<OrderManagementContext> options) : base(options)
        {
        }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
