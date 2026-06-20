using InventoryManagementAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse<T>(T data, string message)
        {
            return Ok(new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            });
        }

        protected IActionResult ErrorResponse(string message)
        {
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Message = message,
                Data = null
            });
        }
    }
}