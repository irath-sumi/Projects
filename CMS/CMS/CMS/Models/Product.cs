

namespace CMS.Models
{
    public class Product
    {
    //    "name": "Apple iPhone 13 mini",
    //    "slug": "apple-iphone-13-mini-5g-base",
    //    "manufacturer": "Apple",
    //    "release_date": "2021-09-17",

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Manufacturer { get; set; }
        public string Release_Date { get; set; }
        public List<Product> products { get; set; }

        //public List<MoboFeaturesContentful> features { get; set; }
        public List<ProductDetails> details { get; set; }

    }

    //public class Product
    //{
    //    public List<Product> products { get; set; }

    //}
}
