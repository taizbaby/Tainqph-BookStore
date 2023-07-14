using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface IProductServices
    {
        public bool CreateProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);

        public List<Product> GetAllProducts();
        public List<Product> GetProductByName(string name);
        public Product GetProductById(Guid id);
    }
}
