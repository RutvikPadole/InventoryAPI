using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Models;
namespace InventoryManagementAPI.Mappings
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
