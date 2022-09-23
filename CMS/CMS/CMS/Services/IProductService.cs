using CMS.Models;

namespace CMS.Services
{
    public interface IProductService
    {
        Task<List<ProductDetails>> GetAllProductsAsync();

       // Task<IQueryable<Product>> GetProducts();
    }
}
