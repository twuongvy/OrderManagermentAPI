namespace Order_Management_API.Model.DTO
{
    public class ResposeDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
