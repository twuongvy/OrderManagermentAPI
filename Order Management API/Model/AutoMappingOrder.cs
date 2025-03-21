using AutoMapper;
using Order_Management_API.Model.DTO;
namespace Order_Management_API.Model
{
    public class AutoMappingOrder : Profile
    {
        public AutoMappingOrder()
        {
            CreateMap<OrderDTO, Orders>();
            CreateMap<Orders, OrderDTO>();
            CreateMap<OrderDetailsDTO, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsDTO>();
        }
    }
    
}
