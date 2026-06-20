    using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;

namespace InventoryManagementAPI.Services;

public interface IProductService
    {
        List<Product> GetAllProducts();
        public Product GetProductById(int id);
        void AddProduct(Product product);
    public void UpdateProduct(Product product);

    public void DeleteProduct(int id);
    }


