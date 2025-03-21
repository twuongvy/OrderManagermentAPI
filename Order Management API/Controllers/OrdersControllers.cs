using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Management_API.Model.DTO;
using Order_Management_API.Services.Orders;

namespace Order_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersControllers : ControllerBase
    {
        private readonly OrderServices _orderServices;
        public OrdersControllers(OrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDTO)
        {

            var result = await _orderServices.CreateOrder(orderDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders(int pageNumber, int pageSize)
        {
            var result = await _orderServices.GetAllOrders(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderServices.GetOrderById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO order)
        {
            var result = await _orderServices.UpdateOrder(id, order);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderServices.DeleteOrder(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPost("/{id}/order-details")]
        public async Task<IActionResult> AddOrderDetails(int id, OrderDetailsDTO orderDetailsDTO)
        {
            var result = await _orderServices.AddOrderDetails(id, orderDetailsDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("/{id}/order-details")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var result = await _orderServices.GetOrderDetails(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
