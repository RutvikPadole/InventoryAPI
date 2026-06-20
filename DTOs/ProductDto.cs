using System.ComponentModel.DataAnnotations;
namespace InventoryManagementAPI.DTOs

{
    public class ProductDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string? Name {  get; set; }

        [Range(1,1000000,ErrorMessage ="Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}
