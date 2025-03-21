using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order_Management_API.Model;
using Order_Management_API.Model.DTO;
using Order_Management_API.Repository.Order;
using Order_Management_API.Repository.OrderDetails;

namespace Order_Management_API.Services.Orders
{
    public class OrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderServices(IOrderRepository orderRepository, IMapper mapper, IOrderDetailsRepository orderDetailsRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<ResposeDTO> CreateOrder(OrderDTO orderDTO)
        {

            var newOrder = _mapper.Map<Model.Orders>(orderDTO);
            return await _orderRepository.AddOrder(newOrder);

        }
        public async Task<List<Model.Orders>> GetAllOrders(int pageNumber, int pageSize)
        {
            return await _orderRepository.GetAllOrders(pageNumber, pageSize);
        }
        public async Task<Model.Orders> GetOrderById(int orderId)
        {
            return await _orderRepository.FindOrderById(orderId);
        }
        public async Task<ResposeDTO> UpdateOrder(int id, OrderDTO ord)
        {
            var order = await _orderRepository.FindOrderById(id);
            if (order != null)
            {
                order.CustomerName = ord.CustomerName;
                order.TotalAmount = ord.TotalAmount;
                order.UpdateAt = DateTime.Now;
                order.Status = ord.Status;

                return await _orderRepository.UpdateOrder(order);
            }
            else
            {
                return new ResposeDTO
                {
                    Message = "Order not found",
                    Success = false
                };
            }
        }
        public async Task<ResposeDTO> DeleteOrder(int id)
        {
            var order = await _orderRepository.FindOrderById(id);
            if (order != null)
            {
                return await _orderRepository.DeleteOrder(order);
            }
            else
            {
                return new ResposeDTO
                {
                    Message = "Order not found",
                    Success = false
                };
            }
        }
        public async Task<ResposeDTO> AddOrderDetails(int OrderId, OrderDetailsDTO orderDetailsDTO)
        {
            var order=await _orderRepository.FindOrderById(OrderId);
            if(order==null)
            {
                return new ResposeDTO
                {
                    Message = "Order not found",
                    Success = false
                };
            }
            var orderDetails = _mapper.Map<Model.OrderDetails>(orderDetailsDTO);
            orderDetails.OrderId = OrderId;
            return await _orderDetailsRepository.AddOrderDetails(orderDetails);
        }
        public async Task<List<Model.OrderDetails>> GetOrderDetails(int id)
        {
            var order= await _orderRepository.FindOrderById(id);
            if(order == null)
            {
                return null;
            }
            return await _orderDetailsRepository.GetOrderDetailsByOrderId(id);
        }
    }
}
