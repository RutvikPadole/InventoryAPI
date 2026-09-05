using InventoryManagementAPI.src.Application;

namespace InventoryManagementAPI.src.Application;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ApiResponse() { }
    public ApiResponse(T data, string message = "Success")
    {
        Success = true;
        Message = message;
        Data = data;
    }
    public ApiResponse(string message)
    {
        Success = false;
        Message = message;
        Data = default;
    }
}


