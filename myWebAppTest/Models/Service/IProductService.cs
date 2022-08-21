using myWebAppTest.Models.Entities;

namespace myWebAppTest.Models.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product AddProduct(Product product);
        void DeleteProduct(int id);
    }
   
}
