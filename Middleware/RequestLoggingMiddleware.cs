namespace InventoryManagementAPI.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("Request Incoming....");
        await _next(context);
        Console.WriteLine("Response Outgoing....");
    }
    
    
}
