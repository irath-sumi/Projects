using AutoMapper.Features;
using CMS.Models;
using Contentful.Core;
using Contentful.Core.Extensions;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Newtonsoft.Json;


namespace CMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IContentfulClient _contentfulClient;
        List<Product> products = new List<Product>();
        public ProductService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
        }
        public async Task<List<ProductDetails>> GetAllProductsAsync()
        {
            products = new List<Product>(); var contentfulProducts = new List<ProductDetails>();
            var jsonData = System.IO.File.ReadAllText("jsonformatter.json");
            var varRootObject_products = JsonConvert.DeserializeObject<Product>(jsonData);

            products.Add(varRootObject_products);
            var entries = await _contentfulClient.GetEntries<MoboFeaturesContentful>();

            // code to fetch only those phones that are in contentful CMS
            //var query = from features in entries.Items
            //            join vpqr in products[0].products on new
            //            {
            //                features.Slug
            //            } equals new
            //            {
            //                vpqr.Slug
            //            }
            //            select vpqr;
            //contentfulProducts.AddRange(query);

            // code to combine and show fields defined in contentful also.

            var query = from features in entries.Items
                        join vpqr in products[0].products on new
                        {
                            features.Slug
                        } equals new
                        {
                            vpqr.Slug
                        }
                        select new ProductDetails() {Name = vpqr.Name, Slug= vpqr.Slug, Manufacturer = vpqr.Manufacturer, 
                            Release_Date = vpqr.Release_Date,Title= features.Title,Introduction= features.Introduction,Paragraphs= features.Paragraphs };
            contentfulProducts.AddRange(query);
           
          
            //contentfulProducts.AddRange((IEnumerable<Product>)entries.Items.);
            // another way - code to fetch only those phones that are in contentful CMS
            //foreach (var entry in entries.Items)
            //{
            //    contentfulProducts.AddRange(products[0].products.Where(xp => xp.Slug == entry.Slug).ToList());
            // }

              
              return contentfulProducts;
         
            
        }
       
    }
}
