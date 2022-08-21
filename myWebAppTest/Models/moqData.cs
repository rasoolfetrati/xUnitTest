using myWebAppTest.Models.Entities;

namespace myWebAppTest.Models
{
    public class moqData
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id=1,Name = "Akbar",Description="Khobe",Price=2500 },
                new Product() { Id=2,Name = "rasool",Description="awlie",Price=50000 },
            };

            return products;
        }
    }
}
