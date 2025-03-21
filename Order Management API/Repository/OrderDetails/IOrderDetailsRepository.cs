using Order_Management_API.Model;
using Order_Management_API.Model.DTO;
namespace Order_Management_API.Repository.OrderDetails
{
    public interface IOrderDetailsRepository
    {
        public Task<Model.OrderDetails> GetOrderDetails(int orderId);
        public Task<List<Model.OrderDetails>> GetOrderDetails();
        public Task<ResposeDTO> AddOrderDetails(Model.OrderDetails orderDetails);
        public Task<ResposeDTO> DeleteOrderDetails(Model.OrderDetails orderDetails);
        public Task<List<Model.OrderDetails>> GetOrderDetailsByOrderId(int orderId);
    }
}
