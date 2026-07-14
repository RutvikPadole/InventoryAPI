using AutoMapper;
using InventoryManagementAPI.src.Application.DTOs;
using InventoryManagementAPI.src.Domain.Model;
namespace InventoryManagementAPI.src.Application.Mappings
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
