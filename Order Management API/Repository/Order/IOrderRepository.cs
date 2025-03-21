using Order_Management_API.Model;
using Order_Management_API.Model.DTO;

namespace Order_Management_API.Repository.Order
{
    public interface IOrderRepository
    {
        public Task<ResposeDTO> AddOrder(Orders order);
        public Task<Orders> FindOrderById(int orderId);
        public Task<ResposeDTO> UpdateOrder(Orders order);
        public Task<List<Orders>> GetAllOrders(int pageNumber, int pageSize);
        public Task<ResposeDTO> DeleteOrder(Orders order);
    }
}
