using myWebAppTest.Models.Entities;

namespace myWebAppTest.Models.Service
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _context;
        public ProductService(DataBaseContext context)
        {
            _context = context;
        }
        public Product AddProduct(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var prc=_context.products.Find(id);
            _context.products.Remove(prc);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.products.Find(id);
        }
    }
}