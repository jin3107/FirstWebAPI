namespace FirstWebAPI.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }

        public ApiResponse(T data, bool success = true, string? message = null) 
        { 
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
