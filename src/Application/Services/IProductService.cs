using InventoryManagementAPI.src.Infrastructure.Repositories;
using InventoryManagementAPI.src.Domain.Model;

namespace InventoryManagementAPI.src.Application.Services;

public interface IProductService
    {
        List<Product> GetAllProducts();
        public Product GetProductById(int id);
        void AddProduct(Product product);
    public void UpdateProduct(Product product);

    public void DeleteProduct(int id);
    }


