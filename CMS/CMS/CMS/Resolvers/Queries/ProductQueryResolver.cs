using CMS.Models;
using CMS.Services;
using Contentful.Core;

namespace CMS.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class ProductQueryResolver
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<ProductDetails>> GetAllProductsAsync([Service] IProductService productService)
        {
            return await productService.GetAllProductsAsync();
        }

    }
}
