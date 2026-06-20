using InventoryManagementAPI.Services;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;
namespace InventoryManagementAPI.Services;

public class ProductService : IProductService

{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public List<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }
    public Product GetProductById(int id)
    {
        return _repository.GetById(id);
    }
    public void AddProduct(Product product)
    {
        _repository.Add(product);
    }
    public void UpdateProduct(Product product)
    {
        _repository.Update(product);
    }
    public void DeleteProduct(int id)
    {
        _repository.Delete(id);
    }

}

