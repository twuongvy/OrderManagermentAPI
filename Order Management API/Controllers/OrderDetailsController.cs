using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Management_API.Model.DTO;
using Order_Management_API.Services.OrderDetails;

namespace Order_Management_API.Controllers
{
    [Route("api/order-details")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsServices _orderDetailsServices;
        public OrderDetailsController(OrderDetailsServices orderDetailsServices)
        {
            _orderDetailsServices = orderDetailsServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderDetails(OrderDetailsDTO orderDetailsDTO)
        {
            var response = await _orderDetailsServices.AddOrderDetails(orderDetailsDTO);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var response = await _orderDetailsServices.GetOrderDetails();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var response = await _orderDetailsServices.GetOrderDetails(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int id)
        {
            var response = await _orderDetailsServices.DeleteOrderDetails(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
