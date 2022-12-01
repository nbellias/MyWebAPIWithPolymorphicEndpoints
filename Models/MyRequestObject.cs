namespace MyWebAPIWithPolymorphicEndpoints.Models
{
    public class MyRequestObject
    {
        public dynamic? Data { get; set; }   
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
