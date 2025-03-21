using Microsoft.EntityFrameworkCore;
using Order_Management_API.Model;
using Order_Management_API.Model.DTO;

namespace Order_Management_API.Repository.OrderDetails
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly OrderManagementContext _context;
        public OrderDetailsRepository(OrderManagementContext orderManagementContext)
        {
            _context = orderManagementContext;
        }
        public async Task<ResposeDTO> AddOrderDetails(Model.OrderDetails orderDetails)
        {
            try
            {
                await _context.OrderDetails.AddAsync(orderDetails);
                await _context.SaveChangesAsync();
                return new ResposeDTO
                {
                    Message = "Order Details created successfully",
                    Success = true,
                    Data = orderDetails
                };
            }
            catch (Exception e)
            {
                return new ResposeDTO
                {
                    Message = $"Something wrong when create order details: {e.Message}",
                    Success = false
                };
            }
        }

        public Task<ResposeDTO> DeleteOrderDetails(Model.OrderDetails orderDetails)
        {
            try
            {
                _context.OrderDetails.Remove(orderDetails);
                _context.SaveChanges();
                return Task.FromResult(new ResposeDTO
                {
                    Message = "Order Details deleted successfully",
                    Success = true
                });
            }
            catch (Exception e)
            {
                return Task.FromResult(new ResposeDTO
                {
                    Message = $"Something wrong when delete order details: {e.Message}",
                    Success = false
                });
            }
        }

        public async Task<Model.OrderDetails> GetOrderDetails(int orderId)
        {
            return await _context.OrderDetails.FindAsync(orderId);
        }

        public async Task<List<Model.OrderDetails>> GetOrderDetails()
        {
            return await _context.OrderDetails.AsQueryable().ToListAsync();
        }

        public async Task<List<Model.OrderDetails>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _context.OrderDetails.AsNoTracking().AsQueryable().Where(x => x.OrderId == orderId).ToListAsync();
        }
    }
}
