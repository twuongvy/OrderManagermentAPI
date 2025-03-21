using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order_Management_API.Model;
using Order_Management_API.Model.DTO;

namespace Order_Management_API.Repository.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderManagementContext _context;
        public OrderRepository(OrderManagementContext orderManagementContext)
        {
            _context = orderManagementContext;
        }
        public async Task<ResposeDTO> AddOrder(Orders order)
        {
            
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return new ResposeDTO
                {
                    Message = "Order created successfully",
                    Success = true,
                    Data = order
                };
            
            

        }

        public Task<ResposeDTO> DeleteOrder(Orders order)
        {
            try
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Task.FromResult(new ResposeDTO
                {
                    Message = "Order deleted successfully",
                    Success = true
                });
            }
            catch (Exception e)
            {
                return Task.FromResult(new ResposeDTO
                {
                    Message = $"Something wrong when delete order: {e.Message}",
                    Success = false
                });
            }
        }

        public async Task<Orders> FindOrderById(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<List<Orders>> GetAllOrders(int pageNumber, int pageSize)
        {
            int total = await _context.Orders.CountAsync();
            return await _context.Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<ResposeDTO> UpdateOrder(Orders order)
        {
            try
            {
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return new ResposeDTO
                {
                    Message = "Order updated successfully",
                    Success = true,
                    Data = order
                };
            }
            catch (Exception e)
            {
                return new ResposeDTO
                {
                    Message = $"Something wrong when update order: {e.Message}",
                    Success = false
                };
            }
        }
        
    }
}
