using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Helpers;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]

    public class ProductController : BaseController

    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, IMapper mapper, ILogger<ProductController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;

            _logger.LogInformation("Fetching all products");
            _logger.LogInformation("Adding new products");
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var products = _service.GetAllProducts();

            var result = _mapper.Map<List<ProductDto>>(products);

            return SuccessResponse(result, "Product fetched successfully");
        }
            


        [HttpPost]
     
        public IActionResult Add(ProductDto dto)

        {
            if (!ModelState.IsValid)
            {
                return ErrorResponse("Invalid data");
            }
                
            var product = _mapper.Map<Product>(dto);

            _service.AddProduct(product);

            var result = _mapper.Map<ProductDto>(product);

            return SuccessResponse(result, "Product added successfully");
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto dto)
        {
            var product = _service.GetProductById(id);

            if (product == null)
            {
                return ErrorResponse("Product not Found");
            }

            _mapper.Map(dto, product);

            _service.UpdateProduct(product);

            var result = _mapper.Map<ProductDto>(product);

            return SuccessResponse(result, "Product updated successfully");
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _service.GetProductById(id);

            if (product == null)
            {
                return ErrorResponse("Product not found");
            }

            _service.DeleteProduct(id);

            return SuccessResponse<string>("Deleted", "Product deleted successfully");
        }   


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetProductById(id);

            if ( product== null)
            {
                return ErrorResponse("Product not found");
            }

            var result = _mapper.Map<ProductDto>(product);

            return SuccessResponse(result, "Product fetched successfully");
        }
    }
}

