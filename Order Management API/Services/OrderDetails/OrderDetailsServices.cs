using AutoMapper;
using Order_Management_API.Model.DTO;
using Order_Management_API.Repository.OrderDetails;

namespace Order_Management_API.Services.OrderDetails
{
    public class OrderDetailsServices
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;
        public OrderDetailsServices(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _mapper = mapper;
        }
        public async Task<ResposeDTO> AddOrderDetails(OrderDetailsDTO orderDetailsDTO)
        {
            var orderDetails = _mapper.Map<Model.OrderDetails>(orderDetailsDTO);
            return await _orderDetailsRepository.AddOrderDetails(orderDetails);
        }
        public async Task<ResposeDTO> DeleteOrderDetails(int id)
        {
            var orderDetails = await _orderDetailsRepository.GetOrderDetails(id);
            if (orderDetails != null)
            {
                return await _orderDetailsRepository.DeleteOrderDetails(orderDetails);
            }
            return new ResposeDTO
            {
                Message = "Order Details not found",
                Success = false
            };
        }
        public async Task<Model.OrderDetails> GetOrderDetails(int orderId)
        {
            var orderDetails = await _orderDetailsRepository.GetOrderDetails(orderId);
            return orderDetails;
        }
        public async Task<List<Model.OrderDetails>> GetOrderDetails()
        {
            var orderDetails = await _orderDetailsRepository.GetOrderDetails();
            return orderDetails;
        }
        
    }
}
